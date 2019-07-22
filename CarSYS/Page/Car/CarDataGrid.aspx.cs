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
    public partial class CarList : System.Web.UI.Page
    {
        CarManager cm = new CarManager();
        BrandManager bm = new BrandManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindCars();

                btnDelects.Attributes.Add("onclick", "return confirm('确定要删除选中的多行数据吗？')");
            }
        }

        public void bindCars()
        {
            try
            {
                dgCars.DataSource = cm.GetCars();
                dgCars.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert(" + ex.Message + ")");
            }
        }


        public List<CarSYSModels.Brand> bindBrands()
        {
            try
            {
                return bm.GetBrands();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void dgCars_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //分页事件
            dgCars.PageIndex = e.NewPageIndex;

            bindCars();
        }

        //每一行被绑定时触发
        protected void dgCars_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Control btnDel = e.Row.Cells[6].FindControl("Button1");
                Button b = (Button)btnDel;

                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    b.Attributes.Add("onclick", "return confirm('确定要删除" + ((Label)(e.Row.Cells[1].FindControl("Label1"))).Text + "')");
                }
                else
                {
                    b.Enabled = false;
                }

                //添加鼠标的高亮显示
                e.Row.Attributes.Add("onmouseover", "backColor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=backColor");


            }

        }

        //删除
        protected void dgCars_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int CarId = Convert.ToInt32(dgCars.DataKeys[e.RowIndex].Value);

            if (cm.DelCarById(CarId) > 0)
            {
                bindCars();
            }

        }

        //删除多行
        protected void btnDelects_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgCars.Rows.Count; i++)
            {
                if (((CheckBox)(dgCars.Rows[i].Cells[0].FindControl("CheckBox2"))).Checked == true)
                {
                    int CarId = Convert.ToInt32(dgCars.DataKeys[i].Value);
                    cm.DelCarById(CarId);
                }
            }
            bindCars();
        }


        //更新
        protected void dgCars_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            FileUpload fuPic = (FileUpload)dgCars.Rows[e.RowIndex].FindControl("fuPic");
            HiddenField hfPic = (HiddenField)dgCars.Rows[e.RowIndex].FindControl("hfPic");

            TextBox txtCarName = (TextBox)dgCars.Rows[e.RowIndex].FindControl("txtCarName");

            DropDownList ddlBrandName = (DropDownList)dgCars.Rows[e.RowIndex].FindControl("ddlBrand");

            TextBox txtPrice = (TextBox)dgCars.Rows[e.RowIndex].FindControl("txtPrice");


            if (fuPic.FileName!="")
            {
                bool isPic = false;
                string fileExtension = System.IO.Path.GetExtension(fuPic.FileName);
                string[] extes = { ".jpg", ".png", ".gif", ".bmp", ".jpeg" };

                foreach (string each in extes)
                {
                    if (each == fileExtension)
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
                        ClientScript.RegisterStartupScript(this.GetType(),"","alert('更新失败，实物图已存在')",true);
                        return;
                    }

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('只能上传jpg、png、gif、bmp、jpeg的图片')", true);
                    return;
                }
                      
            }

            try
            {
                CarSYSModels.Car c = new CarSYSModels.Car();
                c.CarBrand = new Brand();
                c.CarBrand.BrandId = Convert.ToInt32(ddlBrandName.SelectedValue);
                c.CarBrand.BrandName = ddlBrandName.SelectedItem.Text;

                c.CarId = Convert.ToInt32(dgCars.DataKeys[e.RowIndex].Value);
                c.CarName = txtCarName.Text;
                c.OffcialPrice = Convert.ToDecimal(txtPrice.Text);
                c.Picture = hfPic.Value;

                cm.UpdataCarById(c);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('"+ex.Message+"')", true);
            }
           
            dgCars.EditIndex = -1;
            bindCars();
        }

        //取消
        protected void dgCars_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgCars.EditIndex = -1;
            bindCars();
        }

        //编辑
        protected void dgCars_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgCars.EditIndex = e.NewEditIndex;
            bindCars();
        }


    }
}