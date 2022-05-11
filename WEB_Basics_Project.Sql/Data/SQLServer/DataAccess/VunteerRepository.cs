using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WEB_Basics_Project.Sql.Data.SQLServer.DataAccess
{
    public class VounteerRepository
    {
        private DbContext db { get; set; }
        public VounteerRepository() 
        {
            db = new ApplicationDbContext();
        }

        //
        //Your Methods Here
        //

    }
}


