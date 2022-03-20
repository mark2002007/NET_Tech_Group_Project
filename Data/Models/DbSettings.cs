using WEB_Basics_Project.Repository;

namespace WEB_Basics_Project.Data.Models
{
    public class DbSettings : IDbSettings
    {
        public string ConnectionString { get; set; }
    }
}