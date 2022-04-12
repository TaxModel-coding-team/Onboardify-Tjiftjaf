using System;
using System.Collections.Generic;
using System.Linq;
using back_end.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.Stub;

namespace TestProject.Tests
{
    [TestClass]
    public class QuestTest
    {
        private static QuestStub _questStub = new QuestStub();

        [TestMethod]
        public void GetQuestsByUserCorrect()
        {
            List<QuestUserManagement> expected = new List<QuestUserManagement>() {
                new QuestUserManagement(new Guid("A48B0235-5A95-4735-A05D-5AB20D08392A"), 
                    new Guid("A9099ADA-B338-4ACE-B6BC-E13EC0BC1FE9"), false),
                new QuestUserManagement(new Guid("A48B0235-5A95-4735-A05D-5AB20D08392A"), 
                    new Guid("B776559F-81D3-41A9-91ED-7E22DA41F763"), false),
                new QuestUserManagement(new Guid("A48B0235-5A95-4735-A05D-5AB20D08392A"), 
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
                new QuestUserManagement(new Guid("A48B0235-5A95-4735-A05D-5AB20D08392A"), 
                    new Guid("A9099ADA-B338-4ACE-B6BC-E13EC0BC1FE9"), false),
                new QuestUserManagement(new Guid("A48B0235-5A95-4735-A05D-5AB20D08392A"), 
                    new Guid("B776559F-81D3-41A9-91ED-7E22DA41F763"), false),
                new QuestUserManagement(new Guid("A48B0235-5A95-4735-A05D-5AB20D08392A"), 
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
    }
}