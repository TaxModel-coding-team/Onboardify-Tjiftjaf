using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using back_end.ViewModels;
using back_end.DAL;
using back_end.Logic;
using AutoMapper;


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


        [HttpGet]
        [Route("{ID}")]
        public IActionResult GetQuestsByUser(Guid ID)
        {
            var quests = _questlogic.GetQuestsByUser(ID);
            return Ok(quests);
        }

        [HttpPut]
        [Route("complete")]
        public IActionResult CompleteQuest([FromBody] QuestCompletionViewModel completedQuest)
        {
            return Ok(_questlogic.CompleteQuest(completedQuest));
        }

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
                questCompletionViewModel.UserID = userViewModel.ID;
                questCompletionViewModel.SubQuestID = subQuestViewModel.ID;
                questCompletionViewModels.Add(questCompletionViewModel);
            }
        }
    }
}
