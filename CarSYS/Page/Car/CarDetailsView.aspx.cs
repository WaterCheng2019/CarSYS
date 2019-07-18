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
    public partial class Details : System.Web.UI.Page
    {
        CarManager cm = new CarManager();
        BrandManager bm = new BrandManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["CarId"]))
                {
                    //lblInfo.Text = "查看的车辆编号是：" + Request.QueryString["CarId"];

                    int carId = Convert.ToInt32(Request.QueryString["CarId"]);
                    bindCar(carId);
                }
                else
                {
                    bindCar(655424);
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Request.QueryString[‘CarId’]为空')", true);
                }
            }
        }

        public void bindCar(int CarId)
        {
            try
            {
                List<CarSYSModels.Car> cars = new List<CarSYSModels.Car>();

                cars.Add(cm.GetCarById(CarId));

                dtCars.DataSource = cars;
                dtCars.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + ex.Message + "')", true);
            }

        }


        //点击编辑
        protected void dtCars_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            dtCars.ChangeMode(e.NewMode);
            bindCar(Convert.ToInt32(dtCars.DataKey.Value));
        }
        //更新
        protected void dtCars_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            FileUpload fuPic = (FileUpload)dtCars.FindControl("fuPic");
            HiddenField hfPic = (HiddenField)dtCars.FindControl("hfPic");

            TextBox txtCarName = (TextBox)dtCars.FindControl("txtCarName");

            DropDownList ddlBrand = (DropDownList)dtCars.FindControl("ddlBrand");

            TextBox txtPrice = (TextBox)dtCars.FindControl("txtPrice");


            if (fuPic.FileName!="")
            {
                bool isPic = false;
                string fileExtentsion = System.IO.Path.GetExtension(fuPic.FileName);
                string[] extes = { ".jpg", ".png", ".gif", ".bmp", ".jpeg" };

                foreach (string each in extes)
                {
                    if (fileExtentsion== each)
                    {
                        isPic = true;
                        break;
                    }
                }

                if (isPic)
                {
                    string path = Server.MapPath("~/Images/Car/");
                    if (!System.IO.File.Exists(path+fuPic.FileName))
                    {
                        fuPic.PostedFile.SaveAs(path+fuPic.FileName);
                        hfPic.Value = fuPic.FileName;
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新失败，实物图已存在')", true);
                        return;
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(),"", "alert('更新失败，只能上传jpg、png、gif、bmp、jpeg格式的图片')", true);
                    return;
                }

            }
            try
            {
                CarSYSModels.Car c = new CarSYSModels.Car();
                c.CarBrand = new Brand();
                c.CarBrand.BrandId = Convert.ToInt32(ddlBrand.SelectedValue);
                c.CarBrand.BrandName = ddlBrand.SelectedItem.Text;

                c.CarId = Convert.ToInt32(dtCars.DataKey.Value);
                c.CarName = txtCarName.Text;
                c.Picture = hfPic.Value;
                c.OffcialPrice = Convert.ToDecimal(txtPrice.Text);

                cm.UpdataCarById(c);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('"+ex.Message+"')", true);

            }



            dtCars.ChangeMode(DetailsViewMode.ReadOnly);//更新后切换状态
            bindCar(Convert.ToInt32(dtCars.DataKey.Value));
        }
        //新增
        protected void dtCars_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            FileUpload fuAddPic = (FileUpload)dtCars.FindControl("fuAddPic");

            TextBox txtAddCarName = (TextBox)dtCars.FindControl("txtAddCarName");

            DropDownList ddlBrand = (DropDownList)dtCars.FindControl("ddlAddBrand");

            TextBox txtAddPrice=(TextBox)dtCars.FindControl("txtAddPrice");

            if (fuAddPic.FileName!="")
            {
                bool isPic = false;
                string fileExtension = System.IO.Path.GetExtension(fuAddPic.FileName);
                string[] exetis= { ".jpg", ".png", ".gif", ".bmp", ".jpeg" };

                foreach (string exte in exetis)
                {
                    if (exte==fileExtension)
                    {
                        isPic = true;
                        break;
                    }
                }

                if (isPic)
                {
                    string path = Server.MapPath("~/Images/Car/");
                    if (!System.IO.File.Exists(path+fuAddPic.FileName))
                    {
                        fuAddPic.PostedFile.SaveAs(path+fuAddPic.FileName);


                        try
                        {
                            CarSYSModels.Car c = new CarSYSModels.Car();
                            c.CarBrand = new Brand();
                            c.CarBrand.BrandId = Convert.ToInt32(ddlBrand.SelectedValue);
                            c.CarBrand.BrandName = ddlBrand.SelectedItem.Text;

                            c.CarId = Convert.ToInt32(dtCars.DataKey.Value);
                            c.CarName = txtAddCarName.Text;
                            c.Picture = fuAddPic.FileName;
                            c.OffcialPrice = Convert.ToDecimal(txtAddPrice.Text);

                            cm.AddCar3(c);

                            dtCars.ChangeMode(DetailsViewMode.ReadOnly);
                            bindCar(c.CarId);
                        }
                        catch (Exception ex)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + ex.Message + "')", true);
                        }

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新失败，实物图已存在')", true);

                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新失败，只能上传jpg、png、gif、bmp、jpeg格式的图片')", true);
                }


            }






        }


        public List<Brand> bindBrands()
        {
            List<Brand> brands = new List<Brand>();
            try
            {
                brands = bm.GetBrands();
            }
            catch (Exception)
            {
                throw;
            }
            return brands;
        }

    }
}