using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebPresentation.Areas.User.Pages.Profile
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public EditModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGet()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(userId);

            return Page();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(userId);
            //user.FirstName=FirstName;
            //user.LastName = LastName;
            //user.Email = Email
            await _userManager.UpdateAsync(user);
            return RedirectToPage("./index");
        }
    }
}
