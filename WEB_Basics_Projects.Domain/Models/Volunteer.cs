using System.Collections.Generic;

namespace WEB_Basics_Project.Domain
{
    public class Volunteer
    {
        public int? VolunteerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}