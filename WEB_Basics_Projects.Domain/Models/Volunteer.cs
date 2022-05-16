using Microsoft.AspNetCore.Identity;

namespace WEB_Basics_Project.Domain
{
    public class Volunteer : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}