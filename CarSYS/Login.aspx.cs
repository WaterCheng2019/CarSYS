using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarSYSModels;
using CarSYSBLL;

namespace CarSYS
{
    public partial class Login : System.Web.UI.Page
    {
        UserManager um = new UserManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            bool isSuccess = um.isSueescc(txtName.Text, txtPwd.Text);

            if (isSuccess == true)
            {

                string strRedirect = Request["ReturnUrl"];

                System.Web.Security.FormsAuthentication.SetAuthCookie(txtName.Text, ckSave.Checked);

                if (strRedirect == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    Response.Redirect(strRedirect);
                }
            }
            else
            {
                lblInfo.Text = "账号或密码错误！！";
            }

        }
    }
}