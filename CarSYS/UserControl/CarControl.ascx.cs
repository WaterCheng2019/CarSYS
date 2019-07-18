using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarSYSModels;
using CarSYSBLL;

namespace CarSYS.UserControl
{
    public partial class CarControl : System.Web.UI.UserControl
    {
        CarManager cm = new CarManager();

        public int CarId
        {
            get { return Convert.ToInt32(HFId.Value); }
            set { HFId.Value = value.ToString(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Car c = null;
                if (HFId.Value == "")
                {
                     c = cm.GetCarById(1);
                }
                else
                {
                     c = cm.GetCarById(Convert.ToInt32(HFId.Value));
                }


                if (c!=null)
                {
                    lblCarName.Text = c.CarName;
                    lblCarName.Text = c.CarBrand.BrandName;
                    lblClick.Text = c.Click.ToString();
                    lblPrice.Text = c.OffcialPrice.ToString();
                    //imgCar.ImageUrl = "~/Images/Car/" + c.Picture;
                    imgCar.ImageUrl = "~/Images/Car/" + c.Picture;
                }
                else
                {
                    lblCarName.Text = "未查询到此编号的车辆";
                }
            }
            catch (Exception ex)
            {
                lblCarName.Text = ex.Message;
            }

        }
    }
}