namespace WEB_Basics_Project.Sql.Data.SQLServer.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public Volunteer Volunteer { get; set; }
        public string Description { get; set; }
    }
}