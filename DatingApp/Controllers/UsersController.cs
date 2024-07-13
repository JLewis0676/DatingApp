using DatingApp.Data;
using DatingApp.DTO;
using DatingApp.Entities;
using DatingApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{

    [Authorize]
    public class UsersController: BaseAPIController
    {
        private IUserRepository userRepository;
        public UsersController(IUserRepository _userRepo) {
            this.userRepository = _userRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> getUsers()
        {
            var users = await userRepository.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{username}")]

        public async Task<ActionResult<MemberDTO>> GetUser(string username)
        {
            return await userRepository.GetUserByUsernameAsync(username);
        }
    }
}
