using System;
using System.Collections.Generic;
using System.Linq;
using back_end.Logic;
using back_end.Models;
using back_end.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.Stub;
using AutoMapper;
using back_end.Profiles;

namespace TestProject.Tests
{
    [TestClass]
    public class QuestTest
    {
        private static QuestStub _questStub = new QuestStub();
        IMapper _mapper;

        [TestMethod]
        public void GetQuestsByUserCorrect()
        {
            List<QuestUserManagement> expected = new List<QuestUserManagement>() {
                new QuestUserManagement(new Guid("b9b9a3b2-9301-4376-b5f7-7bb9d5d8c8ea"),
                new Guid("A48B0235-5A95-4735-A05D-5AB20D08392A"),
                    new Guid("A9099ADA-B338-4ACE-B6BC-E13EC0BC1FE9"), false),
                new QuestUserManagement(new Guid("b9b9a3b2-9301-4376-b5f7-7bb9d5d8c8ea"),
                new Guid("A48B0235-5A95-4735-A05D-5AB20D08392A"),
                    new Guid("B776559F-81D3-41A9-91ED-7E22DA41F763"), false),
                new QuestUserManagement(new Guid("b9b9a3b2-9301-4376-b5f7-7bb9d5d8c8ea"),
                new Guid("A48B0235-5A95-4735-A05D-5AB20D08392A"),
                    new Guid("1EC79F65-9E4D-4B2F-9AB8-C373F6D849B5"), false)
            };
            List<QuestUserManagement> result = _questStub.GetQuestsByUser(new Guid("A48B0235-5A95-4735-A05D-5AB20D08392A")).ToList();
            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.AreEqual(expected[i].QuestId, result[i].QuestId);
            }
            Assert.AreEqual(expected.Count, result.Count);
        }

        [TestMethod]
        public void GetQuestsByUserFalse()
        {
            List<QuestUserManagement> expected = new List<QuestUserManagement>() {
                new QuestUserManagement(new Guid("b9b9a3b2-9301-4376-b5f7-7bb9d5d8c8ea"),
                new Guid("A48B0235-5A95-4735-A05D-5AB20D08392A"),
                    new Guid("A9099ADA-B338-4ACE-B6BC-E13EC0BC1FE9"), false),
                new QuestUserManagement(new Guid("b9b9a3b2-9301-4376-b5f7-7bb9d5d8c8ea"),
                new Guid("A48B0235-5A95-4735-A05D-5AB20D08392A"),
                    new Guid("B776559F-81D3-41A9-91ED-7E22DA41F763"), false),
                new QuestUserManagement(new Guid("b9b9a3b2-9301-4376-b5f7-7bb9d5d8c8ea"),
                new Guid("A48B0235-5A95-4735-A05D-5AB20D08392A"),
                    new Guid("1EC79F65-9E4D-4B2F-9AB8-C373F6D849B5"), false)
            };
            List<QuestUserManagement> result = _questStub.GetQuestsByUser(new Guid("8D2F1CAF-B64C-4B78-A758-24F0084E36A2")).ToList();
            Assert.AreNotEqual(expected.Count, result.Count);
        }

        [TestMethod]
        public void GetQuestByIdCorrect()
        {
            Quest expected = new Quest(new Guid("623B71BF-C284-47DC-8C22-0AD583393221"), "Test1", "Test1", "Test1", 10);
            Quest result = _questStub.GetQuestById(new Guid("623B71BF-C284-47DC-8C22-0AD583393221"));
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Title, result.Title);
            Assert.AreEqual(expected.Description, result.Description);
            Assert.AreEqual(expected.Category, result.Category);
            Assert.AreEqual(expected.Points, result.Points);
        }

        [TestMethod]
        public void GetQuestByIdFalse()
        {
            Quest expected = new Quest(new Guid("72809FF9-D05A-40CA-B44E-6E4753F211BA"), "Test2", "Test2", "Test2", 20);
            Quest result = _questStub.GetQuestById(new Guid("72809FF9-D05A-40CA-B44E-6E4753F211BA"));
            Assert.AreNotEqual(expected.Id, result.Id);
            Assert.AreNotEqual(expected.Title, result.Title);
            Assert.AreNotEqual(expected.Description, result.Description);
            Assert.AreNotEqual(expected.Category, result.Category);
            Assert.AreNotEqual(expected.Points, result.Points);
        }

        [TestMethod]
        public void AssignBeginnerQuestForUserCorrect()
        {
            //arrange
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.Id = new Guid("fb5058a6-40f3-41fd-8551-18c7f0b1ab75");
            Quest quest = new Quest(new Guid("ab22f8c5-3bf1-4f51-aaa8-9be964f47663"), "Test", "Testcategory", "This is a test", 6, "Beginner");
            _questStub._quests.Add(quest);

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new QuestUserManagementProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            //act
            QuestLogic questLogic = new QuestLogic(_questStub, _mapper);
            bool Result = questLogic.AssignBeginnerQuestForUser(userViewModel);

            //assert
            Assert.AreEqual(userViewModel.Id, _questStub.questusermanagement[0].UserId);
            Assert.AreEqual(quest.Id, _questStub.questusermanagement[0].QuestId);
            Assert.IsTrue(Result);
        }

        [TestMethod]

        public void AssignBeginnerQuestForUserFalse()
        {
            //arrange
            UserViewModel userViewModel = new UserViewModel();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new QuestUserManagementProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            //act
            QuestLogic questLogic = new QuestLogic(_questStub, _mapper);
            bool Result = questLogic.AssignBeginnerQuestForUser(userViewModel);

            //assert
            Assert.IsFalse(Result);
        }
        [TestMethod]

        public void AssignQRQuestForUserCorrect()
        {
            //arrange
            QuestUserViewModel questUserViewModel = new QuestUserViewModel();
            questUserViewModel.Id = new Guid("fb5058a6-40f3-41fd-8551-18c7f0b1ab75");
            questUserViewModel.QuestId = new Guid("fb5058a6-40f3-41fd-8551-18c7f0b1ab75");

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new QuestUserManagementProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            //act
            QuestLogic questLogic = new QuestLogic(_questStub, _mapper);
            bool Result = questLogic.AssignQRQuestForUser(questUserViewModel);

            //assert
            Assert.AreEqual(questUserViewModel.Id, _questStub.questusermanagement[0].UserId);
            Assert.AreEqual(questUserViewModel.QuestId, _questStub.questusermanagement[0].QuestId);
            Assert.IsTrue(Result);
        }
        [TestMethod]

        public void AssignQRQuestForUserFalse()
        {
            //arrange
            QuestUserViewModel questUserViewModel = new QuestUserViewModel();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new QuestUserManagementProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            //act
            QuestLogic questLogic = new QuestLogic(_questStub, _mapper);
            bool Result = questLogic.AssignQRQuestForUser(questUserViewModel);

            //assert
            Assert.IsFalse(Result);
        }
    }
}