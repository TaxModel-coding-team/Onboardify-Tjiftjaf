using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using back_end.ViewModels;
using back_end.Logic;


namespace back_end.Controllers
{
    [Route("quests")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        private readonly QuestLogic _questlogic;

        public QuestController(QuestLogic questlogic)
        {
            _questlogic = questlogic;
        }

        /// <summary>
        /// Gets quests from the database, this is the main page
        /// </summary>
        /// <param name="id">Id of the user</param>
        /// <returns>Page with quests</returns>
        [HttpGet]
        [Route("{ID}")]
        public IActionResult GetQuestsByUser(Guid id)
        {
            var quests = _questlogic.GetQuestsByUser(id);
            return Ok(quests);
        }

        [HttpPut]
        [Route("complete")]
        public IActionResult CompleteQuest([FromBody] QuestCompletionViewModel completedQuest)
        {
            return Ok(_questlogic.CompleteQuest(completedQuest));
        }

        
        //TODO Assign all the basic quests to user instead of going through all created quests (assign the list to user)
        [HttpPost]
        [Route("assignQuests")]
        public ActionResult<UserViewModel> AssignQuests([FromBody] UserViewModel userViewModel)
        {
            List<QuestViewModel> quests =  _questlogic.GetAllQuests();
            List<QuestCompletionViewModel> questCompletionViewModels = new List<QuestCompletionViewModel>();
            foreach(QuestViewModel quest in quests)
            {
                AssignQuestForUser(userViewModel, questCompletionViewModels, quest);
            }
            _questlogic.NewUserQuests(questCompletionViewModels);
            return Ok(quests);
        }

        private void AssignQuestForUser(UserViewModel userViewModel, List<QuestCompletionViewModel> questCompletionViewModels, QuestViewModel quest)
        {
            foreach (SubQuestViewModel subQuestViewModel in quest.SubQuests)
            {
                QuestCompletionViewModel questCompletionViewModel = new QuestCompletionViewModel();
                questCompletionViewModel.UserId = userViewModel.Id;
                questCompletionViewModel.SubQuestId = subQuestViewModel.Id;
                questCompletionViewModels.Add(questCompletionViewModel);
            }
        }
    }
}
