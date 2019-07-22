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
    public partial class AddCar : System.Web.UI.Page
    {
        CarManager cm = new CarManager();
        BrandManager bm = new BrandManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindBrand();
                btnSave.Attributes.Add("onclick","return check()");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (fuPic.FileName!="")
            {

                bool isPic = false;
                string pathExtName = System.IO.Path.GetExtension(fuPic.FileName);
                string[] extes = {".jpg",".svp",".png" };
                foreach (string exte in extes)
                {
                    if (exte==pathExtName)
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
                    }
                    else
                    {
                        lblInfo.Text = "增加失败，实物图已存在";
                        return;
                    }
   
                }
                else
                {
                    lblInfo.Text = "增加失败，只能上传.jpg、.svp、.png格式的图片，请重新选择图片";
                    return;
                }
                       
    

            }



            try
            {
                CarSYSModels.Car c = new CarSYSModels.Car();
                c.CarName = txtName.Text.Trim();
                c.CarBrand = new CarSYSModels.Brand();
                c.CarBrand.BrandId = Convert.ToInt32(ddlBrand.SelectedValue);
                c.CarBrand.BrandName = ddlBrand.SelectedItem.Text;
                c.Picture = fuPic.FileName;
                c.OffcialPrice = Convert.ToDecimal(txtPrice.Text.Trim());
                c.Click = 1;

                cm.AddCar3(c);

                lblInfo.Text = "增加成功，新增的车辆编号是："+c.CarId;

                ClientScript.RegisterStartupScript(this.GetType(), "CleanFrom", "", true);

            }
            catch (Exception ex)
            {
                lblInfo.Text = "增加失败，出现异常，异常信息：" + ex.Message;
            }
        }

        public void bindBrand()
        {
            try
            {
                ddlBrand.DataSource = bm.GetBrands();
                ddlBrand.DataValueField = "BrandId";
                ddlBrand.DataTextField = "BrandName";
                ddlBrand.DataBind();
                ddlBrand.Items.Insert(0, new ListItem("请选择","-1"));
            }
            catch (Exception ex)
            {
                lblInfo.Text = "绑定品牌失败，出现异常，异常信息："+ex.Message;
            }
        }
    }
}