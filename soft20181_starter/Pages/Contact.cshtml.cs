using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    public class ContactModel : PageModel
    {
        public AppDbContext _context { get; set; }

        public ContactModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contact ContactInfo { get; set; }

        public void OnGet()
        {
            // You could fetch contacts here if needed
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                // Save to database
                _context.Contacts.Add(ContactInfo);
                _context.SaveChanges();
                RedirectToPage();
            }
        }

        // New method to clear all contacts
        public IActionResult OnPostClearContacts()
        {
            // Remove all contacts from the table
            _context.Contacts.RemoveRange(_context.Contacts);
            _context.SaveChanges();
            return RedirectToPage(); // Redirect back to the same page or another page
        }
    }
}
