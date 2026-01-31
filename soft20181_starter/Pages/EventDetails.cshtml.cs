using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    [Authorize]
    public class EventDetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public EventDetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Event> Events { get; set; }

        [BindProperty]
        public string SearchQuery { get; set; }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(SearchQuery))
            {
                Events = _context.Events
                    .Where(e => e.Title.Contains(SearchQuery) ||
                                e.Description.Contains(SearchQuery) ||
                                e.Location.Contains(SearchQuery) ||
                                e.Time.Contains(SearchQuery))
                    .ToList();
            }
            else 
            {
                Events = _context.Events.ToList();
            }
        }
    }
}
