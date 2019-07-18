using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarSYSModels;
using CarSYSBLL;

namespace CarSYS.UserControls
{
    public partial class Car : System.Web.UI.UserControl
    {
        CarManager cm = new CarManager();

        public int CarId
        {
            //添加属性，与“HiddenField”控件关联
            get { return Convert.ToInt32(HFId.Value); }
            set { HFId.Value = value.ToString(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (HFId.Value=="")
                    {
                        CarSYSModels.Car c = cm.GetSelectById(1);
                        lblCarName.Text = c.CarName;
                        lblBrandName.Text = c.CarBrand.BrandName;
                        lblClick.Text = c.Click.ToString();
                        lblPrice.Text = c.OfficilPrice.ToString();
                        imaCar.ImageUrl = "~/Images/" + c.Picture;
                    }
                    else
                    {
                        CarSYSModels.Car c = cm.GetSelectById(Convert.ToInt32(HFId.Value));
                        lblCarName.Text = c.CarName;
                        lblBrandName.Text = c.CarBrand.BrandName;
                        lblClick.Text = c.Click.ToString();
                        lblPrice.Text = c.OfficilPrice.ToString();
                        imaCar.ImageUrl = "~/Images/" + c.Picture;
                    }
                    
                }
                catch (Exception ex)
                {
                    lblCarName.Text = ex.Message;
                }
            }
        }
    }
}