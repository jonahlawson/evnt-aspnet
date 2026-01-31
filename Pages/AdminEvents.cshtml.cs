using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    [Authorize(Roles = "Admin")]
    public class AdminEventsModel : PageModel
    {
        private readonly AppDbContext _context;

        public AdminEventsModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Event EventInfo { get; set; }

        public List<Event> Events { get; set; }

        public void OnGet()
        {
            Events = _context.Events.ToList();
        }

        public IActionResult OnPostAdd()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Events.Add(EventInfo);
            _context.SaveChanges();
            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            var eventToDelete = _context.Events.Find(id);
            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                _context.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}
