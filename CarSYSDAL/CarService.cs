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
    public class CarService
    {
        private static SqlConnection conn = new SqlConnection(databaseHelper.connStr);
        string sql = "";
        public void AddCar1(Car c)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into Car(CarName,BrandId,Picture,OffcialPrice,Click) values(");
                sb.AppendFormat("'{0}',", c.CarName);
                sb.AppendFormat("'{0}',",c.CarBrand.BrandId);
                sb.AppendFormat("'{0}',",c.Picture);
                sb.AppendFormat("'{0}',",c.OffcialPrice);
                sb.AppendFormat("'{0}')",c.Click);

                conn.Open();
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                cmd.ExecuteNonQuery();

                sql = "select @@IDENTITY";
                cmd.CommandText = sql;
                c.CarId = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }


        public void AddCar2(Car c)
        {
            sql = "insert into Car(CarName,BrandId,Picture,OffcialPrice,Click) values(@CarName,@BrandId,@Picture,@OffcialPrice,@Click)";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;

                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@CarName",c.CarName),
                    new SqlParameter("@BrandId",c.CarBrand.BrandId),
                    new SqlParameter("@Picture",c.Picture),
                    new SqlParameter("@OffcialPrice",c.OffcialPrice.ToString()),
                    new SqlParameter("@Click",c.Click)
                };

                foreach (SqlParameter para in paras)
                {
                    cmd.Parameters.Add(para);
                }

                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                sql = "select @@IDENTITY";
                cmd.CommandText = sql;
                c.CarId=Convert.ToInt32(cmd.ExecuteScalar());
                
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void AddCar3(Car c)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_AddCar";

                SqlParameter[] paras = new SqlParameter[] 
                {
                    new SqlParameter("@CarName",c.CarName),
                    new SqlParameter("@BrandId",c.CarBrand.BrandId),
                    new SqlParameter("@Picture",c.Picture),
                    new SqlParameter("@OfficialPrice",c.OffcialPrice.ToString()),
                    new SqlParameter("@Click",c.Click),

                    new SqlParameter("@CarId",SqlDbType.Int)

                };

                paras[5].Direction = ParameterDirection.Output;

                foreach (SqlParameter para in paras)
                {
                  
                    cmd.Parameters.Add(para);

                }

                cmd.ExecuteNonQuery();

                c.CarId = Convert.ToInt32(cmd.Parameters["@CarId"].Value.ToString());

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }


        public Car GetCarById (int CarId)
        {
            try
            {
                conn.Open();
                SqlCommand cmd =new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SelectCarById";

                cmd.Parameters.Add(new SqlParameter("@CarId", CarId));

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = ds.Tables[0];

                Car c = null;
                if (dt!=null&&dt.Rows.Count>0)
                {
                    c = new Car();
                    c.CarBrand = new Brand();
                    c.CarBrand.BrandId = Convert.ToInt32(dt.Rows[0]["BrandId"]);
                    c.CarBrand.BrandName = dt.Rows[0]["BrandName"].ToString();

                    c.CarId= Convert.ToInt32(dt.Rows[0]["CarId"]);
                    c.CarName= dt.Rows[0]["CarName"].ToString();
                    c.Picture = dt.Rows[0]["Picture"].ToString();
                    c.OffcialPrice = Convert.ToDecimal(dt.Rows[0]["OffcialPrice"]);
                    c.Click = Convert.ToInt32(dt.Rows[0]["Click"]);

                }
                return c;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }

        public List<Car> GetCars()
        {
            List<Car> cars = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SelectCars";

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                cars = new List<Car>();
                if (ds!=null&&ds.Tables[0].Rows.Count>0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Car c = new Car();
                        c.CarId = Convert.ToInt32(dr["CarId"]);
                        c.CarBrand = new Brand();
                        c.CarBrand.BrandId = Convert.ToInt32(dr["BrandId"]);
                        c.CarBrand.BrandName = dr["BrandName"].ToString();
                        c.CarName = dr["CarName"].ToString();
                        c.OffcialPrice = Convert.ToDecimal(dr["OffcialPrice"]);
                        c.Click = Convert.ToInt32(dr["Click"]);
                        c.Picture = dr["Picture"].ToString();
                        cars.Add(c);
                    }
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                throw;
            }
            finally
            {
                conn.Close();
            }
            return cars;

        }

        public int DelCarById(int CarId)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ups_DelCraById";

                cmd.Parameters.Add(new SqlParameter("@CarId", CarId));

                return cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdataCarById(Car c)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_UpdateCar";

                SqlParameter[] paras = new SqlParameter[] 
                {
                    new SqlParameter("@CarId",c.CarId),
                    new SqlParameter("@CarName",c.CarName),
                    new SqlParameter("@BrandId",c.CarBrand.BrandId),
                    new SqlParameter("@Picture",c.Picture),
                    new SqlParameter("@OffcialPrice",c.OffcialPrice)
                };

                foreach (SqlParameter para in paras)
                {
                    cmd.Parameters.Add(para);
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }


        public DataTable GetCarsBySql(string sql,string order,int pageIndex, int pageSize, ref int totalrecoder)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@sql",sql),
                    new SqlParameter("@order",order),
                    new SqlParameter("@pageindex",pageIndex),
                    new SqlParameter("@pagesize",pageSize),
                    new SqlParameter("@totalrecorder",SqlDbType.Int)
                };

                paras[4].Direction = ParameterDirection.Output;

                SqlCommand cmd = new SqlCommand();
                dt = databaseHelper.ExecuteDataSet(cmd,CommandType.StoredProcedure, "ups_datapage", paras).Tables[0];

                totalrecoder = Convert.ToInt32(cmd.Parameters["@totalrecorder"].Value);


                //dt = databaseHelper.ExecuteDataSet(CommandType.StoredProcedure, "ups_datapage", paras).Tables[0];
                //string sqlStr = "select COUNT(*) from  (" + sql + ")as newTB";
                //totalrecoder = databaseHelper.ExecuteScalar(sqlStr);

            }
            catch (Exception)
            {

                throw;
            }



            return dt;
        }


        
       

        
    }
}
