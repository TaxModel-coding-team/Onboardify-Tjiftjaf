using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Stub;
using User_Back_End.Models;

namespace TestProject.Tests
{
    [TestClass]
    public class UserTest
    {
        private static UserStub stub = new UserStub();

        [TestMethod]
        public void NewUser()
        {
            User expected = new User(new Guid("BD738E5E-D298-4005-BABE-3FA8E7656C00"), "MaxCool@hotmail.com", "MaxCool");
            User testResult = stub.NewUser(expected);
            Assert.AreEqual(expected, testResult);
        }
        [TestMethod]
        public void NewFalseUser()
        {
            User expected = new User(new Guid("8A39236A-FBB0-4AC6-804D-559B8B2B1D64"), "362569@student.fontys.nl");
            User testResult = stub.NewUser(expected);
            Assert.AreNotEqual(expected, testResult);
        }


        [TestMethod]
        public void GetUser()
        {
            User expected = new User(new Guid("55358E6B-D4AE-4293-A493-1061FBD36B7A"), "464748@student.fontys.nl", "jitske");
            User testResult = stub.GetUser(expected);
            Assert.AreEqual(expected, testResult);
        }

        [TestMethod]
        public void GetFalseUser()
        {
            User expected = new User(new Guid("575DD3B5-17F6-4531-987A-32827A769968"), "464748@student.fontys.nl", "jitske");
            User testResult = stub.GetUser(expected);
            Assert.AreNotEqual(expected, testResult);
        }
    }
}
