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
using Xunit;

namespace TestProject.Tests
{
    [TestClass]
    class UserControllerTests
    {
        private HttpClient client;

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
        }

        [TestMethod]
        public async Task GetUser_ReturnsUser_WhenReceivesUserId()
        {
            TestGetUserByIdModel testModel = new TestGetUserByIdModel();
            
            var response = await client.PostAsJsonAsync("/users/Get", );
        }


    }
}
