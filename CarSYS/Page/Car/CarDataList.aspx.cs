using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarSYSBLL;
using CarSYSModels;

namespace CarSYS.Page.Car
{
    public partial class DataListCar : System.Web.UI.Page
    {
        CarManager cm = new CarManager();
        BrandManager bm = new BrandManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindBrand();

                AspNetPager1.AlwaysShow = true;
                AspNetPager1.PageSize = 12;
                AspNetPager1.CurrentPageIndex = 1;
                int TotaCount = 0;
                List<CarSYSModels.Car> cars = cm.GetCarsBySql(Convert.ToInt32(ddlSort.SelectedValue), Convert.ToInt32(ddlBrand.SelectedValue), AspNetPager1.CurrentPageIndex, AspNetPager1.CurrentPageIndex, ref TotaCount);
                AspNetPager1.RecordCount = TotaCount;

                bindCars();


            }
        }

        public void bindCars()
        {
            try
            {
                //List<CarSYSModels.Car> cars = cm.GetCars();

                //PagedDataSource pds = new PagedDataSource();
                //pds.DataSource = cars;
                //pds.AllowPaging = true;

                //pds.PageSize = AspNetPager1.PageSize;
                //pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;

                //dlCars.DataSource = pds;
                //dlCars.DataBind();

                int order = Convert.ToInt32(ddlSort.SelectedValue);
                int BrandId = Convert.ToInt32(ddlBrand.SelectedValue);
                int totalCount = 0;
                List<CarSYSModels.Car> cars = cm.GetCarsBySql(order, BrandId, AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, ref totalCount);
                AspNetPager1.RecordCount = totalCount;

                dlCars.DataSource = cars;
                dlCars.DataBind();

              
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(),"","alert('"+ex.Message+"')",true);
            }
        }

        //点击页码
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            bindCars();
        }

        public void bindBrand()
        {
            try
            {
                ddlBrand.DataSource = bm.GetBrands();
                ddlBrand.DataTextField = "BrandName";
                ddlBrand.DataValueField = "BrandId";
                DataBind();

                ddlBrand.Items.Insert(0, new ListItem("请选择", "-1"));
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + ex.Message + "')", true);
            }
        }

        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCars();
        }

        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            AspNetPager1.CurrentPageIndex = 1;
            bindCars();
        }
    }
}