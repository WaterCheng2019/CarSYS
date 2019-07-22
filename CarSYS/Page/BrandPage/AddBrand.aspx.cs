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
    public partial class AddBrand : System.Web.UI.Page
    {
        BrandManager bm = new BrandManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Brand b = new Brand() { BrandName = txtName.Text };
                bm.AddBrand(b);

                if (b.BrandId==-1)
                {
                    lblInfo.Text = "增加失败，品牌名称已存在，请勿重复添加";
                }
                else
                {
                    lblInfo.Text = "增加成功，新增品牌编号是：" + b.BrandId;
                }
                        

               
            }
            catch (Exception ex)
            {
                lblInfo.Text = "增加失败，出现异常，异常信息："+ex.Message;
            }
        }
    }
}