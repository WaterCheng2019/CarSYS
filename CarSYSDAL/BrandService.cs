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


        public void AddBrand(Brand b)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Clear();

            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@BrandName",b.BrandName),
                new SqlParameter("@BrandId",SqlDbType.Int)
            };
            paras[1].Direction = ParameterDirection.Output;

            databaseHelper.ExecuteNonQuery(cmd, CommandType.StoredProcedure, "ups_AddBrand", paras);

            b.BrandId = Convert.ToInt32(cmd.Parameters["@BrandId"].Value);

        }

        public int DelBrandById(int BrandId)
        {
            try
            {
               
                return databaseHelper.ExecuteNonQuery("usp_DelBrandById", BrandId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Brand GetBrandById(int BrandId)
        {
            Brand b = new Brand();
            DataSet ds = databaseHelper.ExecuteDataSet("usp_SelectBrandById", BrandId);

            if (ds!=null&&ds.Tables[0].Rows.Count>0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    b.BrandId = Convert.ToInt32(dr["BrandId"]);
                    b.BrandName = dr["BrandName"].ToString();
                }
            }

            return b;
        }

        public int UpdateBrandById(Brand b)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@BrandId",b.BrandId),
                new SqlParameter("@BrandName",b.BrandName)
            };
            int val = databaseHelper.ExecuteNonQuery(CommandType.StoredProcedure, "usp_UpdateBrand", paras);
            return val;
        }



    }
}
