using Microsoft.EntityFrameworkCore;


namespace WEB_Basics_Project.Sql.Data.SQLServer.DataAccess
{
    public class ServiceRepository
    {
        private DbContext db { get; set; }
        public ServiceRepository()
        {
            db = new ApplicationDbContext();
        }

        //
        //Your Methods Here
        //

    }
}
