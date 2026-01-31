using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    [Authorize(Roles = "Admin")]
    public class ManageUserModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManageUserModel(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public List<User> users { get; set; }
        public List<IdentityRole> roles { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty]
        public string PasswordString { get; set; }

        [BindProperty]
        public string SelectedRole { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            users = await _userManager.Users.ToListAsync();
            roles = await _roleManager.Roles.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            var user = await _userManager.FindByIdAsync(Id);
            var result = await _userManager.DeleteAsync(user);
            return RedirectToPage("/ManageUser");
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            // Ensure the user exists
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found.");
                return Page();
            }

            // Check if PasswordString is null or empty
            if (string.IsNullOrWhiteSpace(PasswordString))
            {
                ModelState.AddModelError(nameof(PasswordString), "Password cannot be null or empty.");
                await LoadUsersAndRolesAsync(); // Reload users and roles to avoid null references
                return Page();
            }

            // Remove the existing password
            var removePasswordResult = await _userManager.RemovePasswordAsync(user);
            if (!removePasswordResult.Succeeded)
            {
                foreach (var error in removePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                await LoadUsersAndRolesAsync();
                return Page();
            }

            // Add the new password
            var addPasswordResult = await _userManager.AddPasswordAsync(user, PasswordString);
            if (!addPasswordResult.Succeeded)
            {
                foreach (var error in addPasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                await LoadUsersAndRolesAsync();
                return Page();
            }

            return RedirectToPage("/ManageUser");
        }

        private async Task LoadUsersAndRolesAsync()
        {
            users = await _userManager.Users.ToListAsync() ?? new List<User>();
            roles = await _roleManager.Roles.ToListAsync() ?? new List<IdentityRole>();
        }


        public async Task<IActionResult> OnPostChangeRoleAsync()
        {
            var user = await _userManager.FindByIdAsync(Id);
            var currentRole = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRole);
            await _userManager.AddToRoleAsync(user, SelectedRole);
            return RedirectToPage("/ManageUser");
        }

    }
}
