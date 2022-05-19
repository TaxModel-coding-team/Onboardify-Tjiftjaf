using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using User_Back_End.Logic;
using User_Back_End.Logic.LogicInterfaces;
using User_Back_End.Models;
using User_Back_End.ViewModels;

namespace User_Back_End.Controllers
{
    [Route("users")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserGetter _userLogic;
        private readonly IUserSetter _userSetter;
        static HttpClient client = new HttpClient();

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://localhost:44329/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public UserController(IUserGetter userlogic, IUserSetter userSetter)
        {
            _userSetter = userSetter;
            _userLogic = userlogic;
            RunAsync();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<User>> Login([FromBody] UserViewModel userViewModel)
        {
            userViewModel = _userLogic.GetUser(userViewModel);
            if (userViewModel.Username != null) 
            {
                return Ok(userViewModel);
            }
            return StatusCode(404, "User doesn't exist");
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<UserViewModel>> CreateUser([FromBody] UserViewModel userViewModel)
        {
            if (userViewModel.Username != null && userViewModel.Email != null)
            {
                userViewModel = _userSetter.NewUser(userViewModel);
                await CreateUserQuests(userViewModel);
                return CreatedAtAction("CreateUser", userViewModel);
            }
            return StatusCode(404, "Not all fields are filled in");
        }

        [HttpPost]
        [Route("Get")]
        public async Task<ActionResult<UserViewModel>> GetUser([FromBody] UserByIdModel userID)
        {
            if(userID.ID != Guid.Empty)
            {
                return Ok(_userLogic.GetUserByID(userID.ID));

            }
            return StatusCode(500, "Internal server error");
        }

        static async Task<Uri> CreateUserQuests(UserViewModel userViewModel)
        {
            NewUserViewModel newUserViewModel = new NewUserViewModel();
            newUserViewModel.ID = userViewModel.ID;
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "quests/assignQuests", newUserViewModel);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
        }

    }
}
