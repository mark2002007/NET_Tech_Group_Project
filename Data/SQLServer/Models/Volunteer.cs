using System.Collections.Generic;

namespace WEB_Basics_Project.Data.SQLServer.Models
{
    public class Volunteer
    {
        public int VolunteerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Service> Services { get; set; } 
    }
}