using DatingApp.Data;
using DatingApp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{

    [Authorize]
    public class UsersController: BaseAPIController
    {
        private DataContext dataContext;
        public UsersController(DataContext context) {
            this.dataContext = context;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> getUsers()
        {
            var users = await dataContext.Users.ToListAsync();
            return users;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await dataContext.Users.FindAsync(id);
        }
    }
}
