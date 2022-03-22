using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sciv.Models;
using System.Threading.Tasks;

namespace Sciv.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;

        public UserController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult> Details()
        {
            User user = await userManager.GetUserAsync(User);

            UserDTO userDTO = new UserDTO
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return View(userDTO);
        }
    }
}
