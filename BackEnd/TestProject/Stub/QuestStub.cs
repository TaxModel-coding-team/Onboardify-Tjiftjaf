using System;
using System.Collections.Generic;
using back_end.DAL;
using back_end.Models;

namespace TestProject.Stub
{
    public class QuestStub : IQuestRepository
    {
        private ICollection<QuestUserManagement> _test = new List<QuestUserManagement>();
        public List<Quest> _quests = new List<Quest>();
        public List<QuestUserManagement> questusermanagement = new List<QuestUserManagement>();

        public QuestStub()
        {
            _test.Add(new QuestUserManagement(new Guid("b9b9a3b2-9301-4376-b5f7-7bb9d5d8c8ea"), 
                new Guid("A48B0235-5A95-4735-A05D-5AB20D08392A"), 
                new Guid("A9099ADA-B338-4ACE-B6BC-E13EC0BC1FE9"), false));
            _test.Add(new QuestUserManagement(new Guid("b9b9a3b2-9301-4376-b5f7-7bb9d5d8c8ea"),
                new Guid("A48B0235-5A95-4735-A05D-5AB20D08392A"), 
                new Guid("B776559F-81D3-41A9-91ED-7E22DA41F763"), false));
            _test.Add(new QuestUserManagement(new Guid("b9b9a3b2-9301-4376-b5f7-7bb9d5d8c8ea"), 
                new Guid("DC245683-76E2-406D-A7F7-96AF66611B07"), 
                new Guid("0E22A8F4-81C3-4A19-B097-349BAB82E430"), false));
            _test.Add(new QuestUserManagement(new Guid("b9b9a3b2-9301-4376-b5f7-7bb9d5d8c8ea"), 
                new Guid("A48B0235-5A95-4735-A05D-5AB20D08392A"), 
                new Guid("1EC79F65-9E4D-4B2F-9AB8-C373F6D849B5"), false));
        }

        public ICollection<QuestUserManagement> GetQuestsByUser(Guid guid)
        {
            ICollection<QuestUserManagement> questUserManagements = new List<QuestUserManagement>();
            foreach (QuestUserManagement questUserManagement in _test)
            {
                if (questUserManagement.UserId == guid)
                {
                    questUserManagements.Add(questUserManagement);
                }
            }

            return questUserManagements;
        }

        public ICollection<SubQuest> GetSubQuestByQuest(Guid guid)
        {
            throw new NotImplementedException();
        }

        public ICollection<Quest> GetAllQuests()
        {
            throw new NotImplementedException();
        }

        public Quest GetQuestById(Guid id)
        {
            _quests.Add(new Quest(new Guid("623B71BF-C284-47DC-8C22-0AD583393221"), "Test1", "Test1", "Test1", 10));
            if (id == _quests[^1].Id)
            {
                return _quests[^1];
            }
            if (_quests == null)
            {
                throw new NullReferenceException("Failed to return a value.");
            }

            return _quests[^1];
        }

        public bool CompleteQuest(QuestUserManagement questToComplete)
        {
            throw new NotImplementedException();
        }

        public void NewUserQuests(List<QuestUserManagement> questUserManagement)
        {
            throw new NotImplementedException();
        }

        public ICollection<Quest> GetAllBeginnerQuests()
        {
            ICollection<Quest> quests = new List<Quest>();
            foreach(Quest quest in _quests)
            {
                if(quest.Niveau == "Beginner")
                {
                    quests.Add(quest);
                }
            }
            return quests;
        }

        public bool AssignUserQuests(List<QuestUserManagement> quests)
        {
            foreach(QuestUserManagement quest in quests)
            {
                questusermanagement.Add(quest);
            }
            return true;
        }
    }
}