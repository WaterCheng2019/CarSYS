using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSYSDAL;
using CarSYSBLL;


namespace CarSYSBLL
{
    public  class UserManager
    {
        UserService us = new UserService();
        public bool isSueescc(string name,string pwd)
        {
            int count = us.SelectCountByNameAndPwd(name, pwd);

            bool flag = false;

            if (count>0)
            {
                flag= true;
            }
            else
            {
                flag = false;
            }

            return flag; 
        }
    }
}
