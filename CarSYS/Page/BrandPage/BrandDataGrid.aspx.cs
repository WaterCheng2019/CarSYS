using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarSYSModels;
using CarSYSBLL;

namespace CarSYS.Page.BrandPage
{
    public partial class BrandDataGrid : System.Web.UI.Page
    {
        BrandManager bm = new BrandManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindBrand();
            }
        }
        public void bindBrand()
        {
            try
            {
                gvBrand.DataSource = bm.GetBrands();
                gvBrand.DataBind();
            }
            catch (Exception ex)
            {
                lblInfo.Text = "绑定失败，出现异常：" + ex.Message;
            }
        }
        

        //分页
        protected void gvBrand_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvBrand.PageIndex = e.NewPageIndex;
                bindBrand();
            }
            catch (Exception ex)
            {
                lblInfo.Text = "点击分页，出现异常：" + ex.Message;
            }
        }

        //删除
        protected void gvBrand_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int BrandId = Convert.ToInt32(gvBrand.DataKeys[e.RowIndex].Value);
                bm.DelBrandById(BrandId);
                bindBrand();
            }
            catch (Exception ex)
            {
                lblInfo.Text = "删除失败，出现异常：" + ex.Message;
            }
        }

        //绑定行数据触发
        protected void gvBrand_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType==DataControlRowType.DataRow)
            {
                Control c = e.Row.Cells[3].FindControl("Button1");

                Button btnDel = (Button)c;

                if (e.Row.RowState==DataControlRowState.Normal||e.Row.RowState==DataControlRowState.Alternate)
                {
                    btnDel.Attributes.Add("onclick", "return confirm('确定要删除编号为" + ((Label)(e.Row.Cells[1].FindControl("Label1"))).Text + "车辆吗？')");
                }
                else
                {
                    btnDel.Enabled = false;
                }

                //添加高亮显示
                e.Row.Attributes.Add("onmouseover", "backColor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=backColor");        
            }
        }

        //删除多行
        protected void btnDelRows_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <gvBrand.Rows.Count; i++)
            {
                Control c = gvBrand.Rows[i].Cells[0].FindControl("Itemck");

                if (((CheckBox)gvBrand.Rows[i].Cells[0].FindControl("Itemck")).Checked==true)
                {
                    int BrandId = Convert.ToInt32(gvBrand.DataKeys[i].Value);
                    bm.DelBrandById(BrandId);
                }
            }
            bindBrand();
        }

        //编辑
        protected void gvBrand_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBrand.EditIndex = e.NewEditIndex;
            bindBrand();
        }
        //取消
        protected void gvBrand_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBrand.EditIndex = -1;
            bindBrand();
        }
        //更新
        protected void gvBrand_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtBrandId = (TextBox)gvBrand.Rows[e.RowIndex].FindControl("txtBrandId");
            TextBox txtBrandName = (TextBox)gvBrand.Rows[e.RowIndex].FindControl("txtBrandName");

            try
            {
                Brand b = new Brand();
                b.BrandId = Convert.ToInt32(txtBrandId.Text);
                b.BrandName = txtBrandName.Text;
                int val = bm.UpdateBrandById(b);
                if (val>0)
                {
                    gvBrand.EditIndex = -1;
                    bindBrand();
                }
                else
                {
                    lblInfo.Text = "更新失败";
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = "更新失败，出现异常：" + ex.Message;
            }
        }
    }
}