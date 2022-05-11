using Microsoft.EntityFrameworkCore;

namespace WEB_Basics_Project.Sql.Data.SQLServer.DataAccess
{
    public class HotlineRepository
    {
        private DbContext db { get; set; }
        public HotlineRepository()
        {
            db = new ApplicationDbContext();
        }

        //
        //Your Methods Here
        //

    }
}


