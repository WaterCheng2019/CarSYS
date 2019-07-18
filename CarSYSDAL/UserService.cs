using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace CarSYSDAL
{
    public class UserService
    {
        public int SelectCountByNameAndPwd(string name,string pwd)
        {
            return Convert.ToInt32(databaseHelper.ExecuteScalar("usp_SelectCountByNameAndPwd", new String[] { name, pwd }));
        }
    }
}
