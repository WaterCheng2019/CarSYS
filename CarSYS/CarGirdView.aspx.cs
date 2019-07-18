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
    public partial class CarGirdView : System.Web.UI.Page
    {
        CarManager cm = new CarManager();
        BrandManager bm = new BrandManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindCars();
                btnAll.Attributes.Add("onclick", "return confirm('确定要删除选中行吗？')");
            }

        }

        private void bindCars()
        {
            try
            {
                gvCars.DataSource = cm.GetCars();
                gvCars.DataBind();
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }
        public List<Brand> bindBrands()
        {
            List<Brand> brands = null;
            try
            {
                brands = bm.GetBrands();
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
            return brands;
        }

        protected void gvCars_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCars.PageIndex = e.NewPageIndex;
            bindCars();
        }

        //当每一行被绑定时触发
        protected void gvCars_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //如果绑定了数据
                //e.row:获取数据绑定的行，在行中找出对应的单元格
                Control c = e.Row.Cells[6].FindControl("Button1");
                Button btn = (Button)c;//类型转换

                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    if (c != null)
                    {

                        btn.Attributes.Add("onclick", "return confirm('确认要删除" + ((Label)(e.Row.Cells[1].FindControl("Label1"))).Text + "')");
                    }
                }
                else
                {
                    btn.Enabled = false;
                }

                //添加鼠标高亮显示
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff';");

                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            }
        }

        protected void gvCars_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int CarId = Convert.ToInt32(gvCars.DataKeys[e.RowIndex].Value);

                if (cm.DelCarById(CarId) > 0)
                {
                    bindCars();
                    ClientScript.RegisterStartupScript(this.GetType(), "ad", "alert('删除成功！！')", true);
                }




            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            for (int rowindex = 0; rowindex < gvCars.Rows.Count; rowindex++)
            {

                if (((CheckBox)gvCars.Rows[rowindex].Cells[0].FindControl("Checkbox2")).Checked == true)
                {
                    int CarId = Convert.ToInt32(gvCars.DataKeys[rowindex].Value);
                    cm.DelCarById(CarId);
                }
            }
            bindCars();
        }
        //编辑
        protected void gvCars_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCars.EditIndex = e.NewEditIndex;
            bindCars();
        }
        //更新
        protected void gvCars_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            lblInfo.Text = "";
            FileUpload fuPic = ((FileUpload)(gvCars.Rows[e.RowIndex].FindControl("fuPic")));

            HiddenField hfPic = ((HiddenField)gvCars.Rows[e.RowIndex].FindControl("hfPic"));

            TextBox txtName = (TextBox)gvCars.Rows[e.RowIndex].FindControl("TextBox1");

            DropDownList ddlBrand = (DropDownList)gvCars.Rows[e.RowIndex].FindControl("ddrBrandName");

            TextBox txtPrice = (TextBox)gvCars.Rows[e.RowIndex].Cells[3].Controls[0];

            if (fuPic.FileName != "")
            {
                bool isPic = false;
                string fileExtesion = System.IO.Path.GetExtension(fuPic.FileName);
                string[] exts = { ".jpg", ".png", ".gif", ".bmp", ".jpeg" };
                foreach (string each in exts)
                {
                    if (fileExtesion == each)
                    {
                        isPic = true;
                        break;
                    }
                }

                if (isPic)
                {
                    string path = Server.MapPath("~/Images/");//获取服务器的物理路径

                    if (!System.IO.File.Exists(path + fuPic.FileName))//判断图片是否已存在
                    {
                        fuPic.PostedFile.SaveAs(path + fuPic.FileName);//保存图片

                        hfPic.Value = fuPic.FileName;//保存新的文件名

                    }
                    else
                    {
                        lblInfo.Text = "实物图已存在，更新失败";
                        return;
                    }


                }
                else
                {
                    lblInfo.Text = "只能上传gif、png、gif、bmp和jpeg的图片";
                    return;
                }
            }
            try
            {
                Car c = new Car();
                c.CarBrand = new Brand();
                c.CarBrand.BrandId = Convert.ToInt32(ddlBrand.SelectedValue);
                c.CarBrand.BrandName = ddlBrand.SelectedItem.Text;
                c.CarId = Convert.ToInt32(gvCars.DataKeys[e.RowIndex].Value);
                c.CarName = txtName.Text;
                c.OfficilPrice = Convert.ToDecimal(txtPrice.Text);
                c.Picture = hfPic.Value;

                cm.UpdateCarById(c);

            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }

            gvCars.EditIndex = -1;
            bindCars();




        }
        //取消
        protected void gvCars_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCars.EditIndex = -1;
            bindCars();
        }
    }
}