using WEB_Basics_Project.Sql;

namespace WebAPI.Models.Settings
{
    public class DbSettings : IDbSettings
    {
        public string ConnectionString { get; set; }
    }
}