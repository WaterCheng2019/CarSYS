using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarSYSModels;
using CarSYSBLL;

namespace CarSYS.Page.Car
{
    public partial class CarRepeater : System.Web.UI.Page
    {
        CarManager cm = new CarManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                aspPage.AlwaysShow = true;
                aspPage.CurrentPageIndex = 1;
                aspPage.PageSize = 5;
                int totalCount = 0;
                cm.GetCarsBySql(aspPage.CurrentPageIndex, aspPage.PageSize,ref totalCount);
                aspPage.RecordCount = totalCount;

                bindCar();
            }
        }
        public void bindCar()
        {
            try
            {
                int totalCount = 0;
                List<CarSYSModels.Car> cars = cm.GetCarsBySql(aspPage.CurrentPageIndex, aspPage.PageSize, ref totalCount);

                aspPage.RecordCount = totalCount;


                carRepeater.DataSource = cars;
                carRepeater.DataBind();
            }
            catch (Exception ex)
            {
                lblInfo.Text = "绑定Repearter异常："+ex.Message;
            }
        }

        protected void aspPage_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            aspPage.CurrentPageIndex = e.NewPageIndex;
            bindCar();
        }
    }
}