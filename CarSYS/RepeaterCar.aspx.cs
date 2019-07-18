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
    public partial class RepeaterCar : System.Web.UI.Page
    {
        CarManager cm = new CarManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindCars();
            }
        }
        public void bindCars()
        {
            repeaterCar.DataSource = cm.GetCars();
            repeaterCar.DataBind();
        }

        protected void repeaterCar_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int carId = Convert.ToInt32(e.CommandArgument);
            string name = e.CommandName.ToLower();

            switch (name)
            {
                case "del":
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除的车型编号:"+carId+"的车型')", true);

                    break;
                case "edit":
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改的车型编号:" + carId + "的车型')", true);

                    break;
            }

        }
    }
}