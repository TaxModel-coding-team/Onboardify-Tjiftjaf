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
            if (quests[0].Description == null && quests[0].Category == null)
            {
                return StatusCode(405, "Data incorrect");
            }
            else if(quests == null)
            {
                return StatusCode(503, Console.ReadLine());
            }else
            {
                return (IActionResult)quests;
            }
        }

        [HttpPut]
        [Route("complete")]
        public IActionResult CompleteQuest([FromBody] QuestUserViewModel questUserViewModel)
        {
            if (_questlogic.CompleteQuest(questUserViewModel) ==  true)
            {
                return Ok(_questlogic.CompleteQuest(questUserViewModel));
            }
            else
            {
                return StatusCode(503, Console.ReadLine());
            }
        }

        [HttpPost]
        [Route("assignQuests")]
        public ActionResult<QuestUserViewModel> AssignQuests([FromBody] UserViewModel userViewModel)
        {
            if(_questlogic.AssignBeginnerQuestForUser(userViewModel)== true)
            {
                return Ok(true);
            }
            else
            {
                return StatusCode(503, Console.ReadLine());
            }
        }

        [HttpPost]
        [Route("assignQRQuests")]
        public ActionResult<QuestUserViewModel> AssignQRQuest([FromBody] QuestUserViewModel questUserViewModel)
        {
            if(_questlogic.AssignQRQuestForUser(questUserViewModel) == true)
            {
                return Ok(true);
            }
            else
            {
                return StatusCode(503, Console.ReadLine());
            }
        }
    }
}
