using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.TestModels;
using TestProject.Stub;
using User_Back_End.ViewModels;


namespace TestProject.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        private HttpClient client;
        private UserLogicStub stub;

        [TestInitialize]
        public async void Init()
        {
            var hostBuilder = new HostBuilder()
            .ConfigureWebHost(webHost =>
            {
                // Add TestServer
                webHost.UseTestServer();

                // Specify the environment
                webHost.UseEnvironment("Test");

                webHost.Configure(app => app.Run(async ctx => await ctx.Response.WriteAsync("Hello World!")));
            });
            var host = await hostBuilder.StartAsync();
            client = host.GetTestClient();
            List<UserViewModel> testData = new List<UserViewModel>();
            for (int i = 0; i <= 5; i++)
            {
                Guid guid = Guid.NewGuid();
                UserViewModel testModel = new UserViewModel();
                testModel.ID = guid;
                testData.Add(testModel);
            }
        }

        [TestMethod]
        public async void GetUser_ReturnsUser_WhenReceivesUserId()
        {
            Init();
            Guid guid = Guid.NewGuid();
            Console.WriteLine(guid);
            TestGetUserByIdModel testModel = new TestGetUserByIdModel(guid);
            
            var response = await client.PostAsJsonAsync("/users/Get", testModel);

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }


    }
}
