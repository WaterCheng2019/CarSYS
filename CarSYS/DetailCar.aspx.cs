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
    public partial class DetailCar : System.Web.UI.Page
    {
        CarManager cm = new CarManager();
        BrandManager bm = new BrandManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string carId = Request.QueryString["CarId"];
                if (!String.IsNullOrEmpty(carId))
                {
                    int CarId = int.Parse(carId);
                    bindCarId(CarId);
                }


            }
        }

        public void bindCarId(int CarId)
        {
            try
            {
                List<Car> cars = cm.GetCarById(CarId);
                dvCars.DataSource = cars;
                dvCars.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + ex.Message + "')", true);
            }
        }

        public List<Brand> bindBrands()
        {
            try
            {
                return bm.GetBrands();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //切换编辑的状态
        protected void dvCars_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {

            dvCars.ChangeMode(e.NewMode);
            bindCarId(Convert.ToInt32(dvCars.DataKey.Value));
        }

        //更新·
        protected void dvCars_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            FileUpload fuPic = (FileUpload)(dvCars.FindControl("fulPic"));

            HiddenField hfPic = (HiddenField)dvCars.FindControl("hflPic");

            TextBox txtCarName = (TextBox)dvCars.FindControl("txtCarName");

            DropDownList ddlBrand = (DropDownList)dvCars.FindControl("ddlEditBrand");

            TextBox txtPrice = (TextBox)dvCars.FindControl("txtPrice");

            if (fuPic.FileName != "")
            {
                bool isPic = false;
                string fileExtension = System.IO.Path.GetExtension(fuPic.FileName);
                string[] exts = { ".png", ".gif", ".jpg", ".bmp", ".jpeg" };
                foreach (string each in exts)
                {
                    if (each == fileExtension)
                    {
                        isPic = true;
                        break;
                    }
                }

                if (isPic)
                {
                    string path = Server.MapPath("~/Images/");
                    if (!System.IO.File.Exists(path + fuPic.FileName))
                    {
                        fuPic.PostedFile.SaveAs(path + fuPic.FileName);
                        hfPic.Value = fuPic.FileName;//保存文件名
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('实物图已存在！！')", true);
                        return;
                    }

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('只能上传gif、png、gif、bmp和jpeg的图片！！')", true);
                    return;
                }


            }

            try
            {
                Car c = new Car();
                c.CarBrand = new Brand();
                c.CarBrand.BrandId = Convert.ToInt32(ddlBrand.SelectedValue);
                c.CarBrand.BrandName = ddlBrand.SelectedItem.Text;
                c.CarId = Convert.ToInt32(dvCars.DataKey.Value);
                c.CarName = txtCarName.Text;
                c.OfficilPrice = Convert.ToDecimal(txtPrice.Text);
                c.Picture = hfPic.Value;

                cm.UpdateCarById(c);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + ex.Message + "')", true);
            }

            dvCars.ChangeMode(DetailsViewMode.ReadOnly);//切状态
            bindCarId(Convert.ToInt32(dvCars.DataKey.Value));

        }

        //新增插入
        protected void dvCars_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            FileUpload fuPic = (FileUpload)dvCars.FindControl("fulAddPic");

            TextBox txtName = (TextBox)dvCars.FindControl("txtAddCarName");

            DropDownList ddlBrand = (DropDownList)dvCars.FindControl("ddlInsertBrand");

            TextBox txtPrice = (TextBox)dvCars.FindControl("txtAddPrice");

            bool isPic = false;

            string fileExtension = System.IO.Path.GetExtension(fuPic.FileName);
            string[] exts = { ".png", ".gif", ".jpg", ".bmp", ".jpeg" };
            foreach (string each in exts)
            {
                if (each == fileExtension)
                {
                    isPic = true;
                    break;
                }
            }

            if (isPic)
            {
                string path = Server.MapPath("~/Images/");
                if (!System.IO.File.Exists(path+fuPic.FileName))
                {
                    fuPic.PostedFile.SaveAs(path+fuPic.FileName);


                    try
                    {
                        Car c = new Car();
                        c.CarBrand = new Brand();
                        c.CarBrand.BrandId = Convert.ToInt32(ddlBrand.SelectedValue);
                        c.CarBrand.BrandName = ddlBrand.SelectedItem.Text;
                        c.CarId = Convert.ToInt32(dvCars.DataKey.Value);
                        c.CarName = txtName.Text;
                        c.OfficilPrice = Convert.ToDecimal(txtPrice.Text);
                        c.Picture = fuPic.FileName;

                        cm.AddCar(c);

                        dvCars.ChangeMode(DetailsViewMode.ReadOnly);//切状态
                        bindCarId(c.CarId);

                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + ex.Message + "')", true);
                    }

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加失败,实物图已存在！！')", true);
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('只能上传gif、png、gif、bmp和jpeg的图片！！')", true);
            }



        }
    }
}