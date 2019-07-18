using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CarSYSModels;

namespace CarSYSDAL
{
    public class BrandService
    {

        private static SqlConnection conn = new SqlConnection(databaseHelper.connStr);

        public List<Brand> GetBrnads()
        {
            List<Brand> brans = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SelectBrand";

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                brans = new List<Brand>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Brand b = new Brand();
                    b.BrandId = Convert.ToInt32(dr["BrandId"]);
                    b.BrandName = dr["BrandName"].ToString();
                    brans.Add(b);
                }

                return brans;

            }
            catch (Exception ex)
            {
                throw new Exception("GetBrands",ex);
            }
            finally
            {
                conn.Close();
            }


        }



    }
}
