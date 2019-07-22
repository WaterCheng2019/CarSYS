using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarSYSBLL;
using CarSYSModels;

namespace CarSYS.Page.BrandPage
{
    public partial class DetailsView : System.Web.UI.Page
    {
        BrandManager bm = new BrandManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["BrandId"] != null)
                {
                    int BrandId = Convert.ToInt32(Request.QueryString["BrandId"]);
                    dvBrand.DataSource = bm.GetBrands();
                    dvBrand.DataBind();
                }
                else
                {
                    lblInfo.Text = "BrandId字段为空";
                }
            }
            
                   
        }

        public void bindBrandById(int brandId)
        {
            try
            {
                dvBrand.DataSource = bm.GetBrands();
                dvBrand.DataBind();
            }
            catch (Exception ex)
            {
                lblInfo.Text = "绑定失败，异常："+ex.Message;
            }
        }

        //改变状态
        protected void dvBrand_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            dvBrand.ChangeMode(e.NewMode);
            bindBrandById(Convert.ToInt32(dvBrand.DataKey.Value));
        }

        //更新
        protected void dvBrand_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            TextBox txtBrandId = (TextBox)dvBrand.FindControl("txtBrandId");
            TextBox txtBrandName = (TextBox)dvBrand.FindControl("txtBrandName");
            try
            {
                Brand b = new Brand();
                b.BrandId = Convert.ToInt32(txtBrandId.Text);
                b.BrandName = txtBrandName.Text;
                bm.UpdateBrandById(b);

                dvBrand.ChangeMode(DetailsViewMode.ReadOnly);
                bindBrandById(Convert.ToInt32(dvBrand.DataKey.Value));
            }
            catch (Exception ex)
            {
                lblInfo.Text = "更新失败，异常：" + ex.Message;
            }
        }

        //插入
        protected void dvBrand_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            TextBox txtBrandName = (TextBox)dvBrand.FindControl("txtAddBrandName");
            try
            {
                Brand b = new Brand();
                b.BrandName = txtBrandName.Text;

                bm.AddBrand(b);

                if (b.BrandId==-1)
                {
                    lblInfo.Text = "新增失败，品牌名称已存在";
                    return;
                }

                lblInfo.Text = "新增成功，新增的编号："+b.BrandId;

                dvBrand.ChangeMode(DetailsViewMode.ReadOnly);
                bindBrandById(b.BrandId);
            }
            catch (Exception ex)
            {
                lblInfo.Text = "新增失败，异常：" + ex.Message;
            }
        }
    }
}