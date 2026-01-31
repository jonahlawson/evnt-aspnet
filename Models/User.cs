using Microsoft.AspNetCore.Identity;

namespace soft20181_starter.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
