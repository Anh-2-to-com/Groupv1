using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;
using System.Data.SqlClient;
using ProjectPublic.Models;

namespace ProjectPublic.Controllers
{
    public class UserBL
    {
        public string pConnectionString { get; set; }
        private SQLClass db;

        public UserBL()
        {
            db = new SQLClass();
            db.CreateConnection(pConnectionString);
        }
        public User getUser(string userName, string password)
        {
            User nd = new User();
            string sql = "SELECT * FROM tb_user WHERE username = "+userName+" AND password = "+password+"";
            nd = (User)db.ExecuteScalar(sql);
            return nd;
        }
    }
}
