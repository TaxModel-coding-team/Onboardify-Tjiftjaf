using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Stub;
using User_Back_End.Models;
using User_Back_End.Logic;
using User_Back_End.ViewModels;
using User_Back_End.DAL;
using AutoMapper;

namespace TestProject.Tests
{
    [TestClass]
    public class UserTest
    {
        /// <summary>
        /// All Unit tests work but you need to Run them by pressing debug all. 
        /// If you run them normally you get an ironbar error for a QR code license
        /// </summary>
        private static UserStub stub = new UserStub();
        IMapper _mapper;

        [TestMethod]
        public void NewUser()
        {
            //Arrange
            UserViewModel userviewmodel = new UserViewModel();
            userviewmodel.ID = new Guid("BD738E5E-D298-4005-BABE-3FA8E7656C00");
            userviewmodel.Email = "MaxCool@hotmail.com";
            userviewmodel.Username = "MaxCool";
            
            if(_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new UserMappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            UserLogic userlogic = new UserLogic(stub, _mapper);
            //Act
            var Result =  userlogic.NewUser(userviewmodel);
            
            //Assert
            Assert.AreEqual(userviewmodel.Email, Result.Email);
            Assert.AreEqual(userviewmodel.Email, stub.Tests[0].Email);
            Assert.AreEqual(userviewmodel.ID, Result.ID);
            Assert.AreEqual(userviewmodel.ID, stub.Tests[0].ID);
            Assert.AreEqual(userviewmodel.Username, Result.Username);
            Assert.AreEqual(userviewmodel.Username, stub.Tests[0].Username);
        }

        [TestMethod]
        public void NewFalseUser()
        {
            //Arrange
            UserViewModel userviewmodel = new UserViewModel();
            userviewmodel.ID = new Guid("8A39236A-FBB0-4AC6-804D-559B8B2B1D64");
            userviewmodel.Email = "362569@student.fontys.nl";
            userviewmodel.Username = "Pietje";

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new UserMappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            UserLogic userlogic = new UserLogic(stub, _mapper);
            //Act
            var Result = userlogic.NewUser(userviewmodel);

            //Assert
            Assert.AreNotEqual(userviewmodel, Result);
            Assert.AreEqual(userviewmodel.Email, stub.Tests[0].Email);
            Assert.AreEqual(userviewmodel.ID, stub.Tests[0].ID);
            Assert.AreEqual(userviewmodel.Username, stub.Tests[0].Username);
        }

        [TestMethod]
        public void GetUser()
        {
            //Arrange
            UserViewModel userviewmodel = new UserViewModel();
            userviewmodel.ID = new Guid("55358E6B-D4AE-4293-A493-1061FBD36B7A");
            userviewmodel.Email = "464748@student.fontys.nl";
            userviewmodel.Username = "jitske";

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new UserMappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            UserLogic userlogic = new UserLogic(stub, _mapper);
            //Act
            var Result = userlogic.GetUser(userviewmodel);

            //Assert
            Assert.AreEqual(userviewmodel.ID, Result.ID);
            Assert.AreEqual(userviewmodel.Username, Result.Username);
            Assert.AreEqual(userviewmodel.Email, Result.Email);
            Assert.AreEqual(userviewmodel.ID, stub.Tests[0].ID);
            Assert.AreEqual(userviewmodel.Username, stub.Tests[0].Username);
            Assert.AreEqual(userviewmodel.Email, stub.Tests[0].Email);
        }

        [TestMethod]
        public void GetFalseUser()
        {
            //Arrange
            UserViewModel userviewmodel = new UserViewModel();
            userviewmodel.ID = new Guid("5535aE6B-D4AE-4293-A493-1064FBD36B7A");
            userviewmodel.Email = "464748@student.fontys.nl";
            userviewmodel.Username = "jitske";

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new UserMappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            UserLogic userlogic = new UserLogic(stub, _mapper);
            //Act
            var Result = userlogic.GetUser(userviewmodel);

            //Assert
            Assert.IsNull(Result);
        }
    }
}
