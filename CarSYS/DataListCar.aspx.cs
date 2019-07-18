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
    public partial class DataListCar : System.Web.UI.Page
    {
        CarManager cm = new CarManager();
        BrandManager bm = new BrandManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindBrands();

                AspNetPager1.AlwaysShow = true;
                AspNetPager1.CurrentPageIndex = 1;
                AspNetPager1.PageSize = 3;
                int totalCount = 0;

                List<Car> cars = cm.GetCarsBySql(int.Parse(ddlSort.SelectedValue),int.Parse(ddlBrand.SelectedValue),AspNetPager1.CurrentPageIndex,AspNetPager1.PageSize,ref totalCount);
                AspNetPager1.RecordCount = totalCount;

                bindCars();
            }
        }

        //public void bindCars()
        //{
        //    try
        //    {
        //        dtCars.DataSource = cm.GetCars();
        //        dtCars.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + ex.Message + "')", true);
        //    }
        //}

        ////分页
        //public void bindCars()
        //{
        //    try
        //    {
        //        List<Car> cars = cm.GetCars();
        //        PagedDataSource pds = new PagedDataSource();
        //        pds.DataSource = cars;
        //        pds.AllowPaging = true;
        //        pds.PageSize = 3;
        //        pds.CurrentPageIndex = 0;


        //        dtCars.DataSource = pds;
        //        dtCars.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + ex.Message + "')", true);
        //    }
        //}

        //第三方控件分页
        public void bindCars()
        {
            try
            {
                //List<Car> cars = cm.GetCars();
                int totalCount = 0;
                List<Car> cars= cm.GetCarsBySql(int.Parse(ddlSort.SelectedValue), int.Parse(ddlBrand.SelectedValue), AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize, ref totalCount);

                AspNetPager1.RecordCount = totalCount;
                dtCars.DataSource = cars;
                dtCars.DataBind();
                 
                //PagedDataSource pds = new PagedDataSource();
            //    pds.DataSource = cars;
            //    pds.AllowPaging = true;


            //    pds.PageSize = AspNetPager1.PageSize;
            //    pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex-1;


            //    dtCars.DataSource = pds;
            //    dtCars.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + ex.Message + "')", true);
            }
        }

        public void bindBrands()
        {
            try
            {
                ddlBrand.DataSource = bm.GetBrands();
                ddlBrand.DataTextField = "BrandId";
                ddlBrand.DataValueField = "BrandName";
                ddlBrand.DataBind();
                ddlBrand.Items.Insert(0, new ListItem("请选择", "-1"));

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + ex.Message + "')", true);
            }
        }

        //分页
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            bindCars();
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