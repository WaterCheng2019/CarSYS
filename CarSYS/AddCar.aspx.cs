using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarSYSModels;
using CarSYSBLL;
using System.IO;


namespace CarSYS
{
    public partial class AddCar : System.Web.UI.Page
    {
        CarManager cm = new CarManager();
        BrandManager bm = new BrandManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    List<Brand> brands = bm.GetBrands();
                    ddlBrand.DataSource = brands;
                    ddlBrand.DataTextField = "BrandName";
                    ddlBrand.DataValueField = "BrandId";
                    ddlBrand.DataBind();
                    ddlBrand.Items.Insert(0, new ListItem("请选择", "-1"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(fuPic.FileName) || string.IsNullOrEmpty(ddlBrand.Text))
            {
                Response.Write("请输入完整信息！！");
                return;
            }
            try
            {
                string path = Server.MapPath("~/Images/");
                bool isPic = false;
                string fileExtension = Path.GetExtension(fuPic.FileName);
                string[] exts = { ".gif", ".png", ".jpg", ".bmp", ".jpeg" };
                foreach (string each in exts)
                {
                    if (fileExtension == each)
                    {
                        isPic = true;
                        break;
                    }
                }

                if (isPic)
                {
                    //判断图片是否在服务器中存在
                    if (!File.Exists(path + fuPic.FileName))
                    {
                        fuPic.PostedFile.SaveAs(path + fuPic.FileName);//文件另存服务器指定目录下

                        Car c = new Car();
                        c.CarBrand = new Brand();
                        c.CarBrand.BrandId = Convert.ToInt32(ddlBrand.SelectedValue);
                        c.CarBrand.BrandName = ddlBrand.SelectedItem.Text;
                        c.CarName = txtName.Text;
                        c.OfficilPrice = Convert.ToDecimal(txtPrice.Text);
                        c.Picture = txtPrice.Text;
                        c.Picture = fuPic.FileName;
                        c.Click = 1;
                        cm.AddCar(c);
                        lblInfo.Text = "实物图上传成功！,增加成功！！车型号是：" + c.CarId;


                    }
                    else
                    {
                        lblInfo.Text = "实物图已经存在！！";
                    }

                }
                else
                {
                    lblInfo.Text = "只能上传.gif、.png、.jpg、 .bmp、 .jpeg图像文件";
                }




            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }

        }
    }
}