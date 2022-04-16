using System.Collections.Generic;

namespace WEB_Basics_Project.Data.SQLServer.Models
{
    public class Volunteer
    {
        public int VolunteerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<string> Position { get; set; }
    }
}