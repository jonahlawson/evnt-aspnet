using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    public class EventsModel : PageModel
    {
        private readonly AppDbContext _context;

        public EventsModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Event> Events { get; set; }

        public void OnGet()
        {
            Events = _context.Events.ToList();
        }
    }
}
