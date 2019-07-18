using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSYSDAL;
using CarSYSModels;

namespace CarSYSBLL
{
    public class CarManager
    {
        CarService cs = new CarService();

        public void AddCar1(Car c)
        {
            try
            {
                cs.AddCar1(c);
            }
            catch (Exception)
            { 
                throw;
            }


        }

        public void AddCar2(Car c)
        {
            try
            {
                cs.AddCar2(c);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddCar3(Car c)
        {
            try
            {
                cs.AddCar3(c);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Car GetCarById(int CarId)
        {
            try
            {
                return cs.GetCarById(CarId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Car> GetCars()
        {
            try
            {
                return cs.GetCars();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int DelCarById(int CarId)
        {
            try
            {
                return cs.DelCarById(CarId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdataCarById(Car c)
        {
            try
            {
                cs.UpdataCarById(c);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Car> GetCarsBySql(int order,int BrandId,int pageIndex,int pageSize,ref int totalrecoder)
        {
            List<Car> cars = null;
            System.Data.DataTable dt = new System.Data.DataTable();


            string sql = "select CarId,CarName,Brand.BrandId,BrandName,Picture,OffcialPrice,Click from Car,Brand where Car.BrandId=Brand.BrandId";

            //根据品牌添加查询条件
            if (BrandId!=-1)
            {
                sql += " and Brand.BrandId=" + BrandId;
            }

           
            try
            {
                if (order == 0)
                {
                    //按价格排序
                    dt = cs.GetCarsBySql(sql, " OffcialPrice desc ", pageIndex, pageSize, ref totalrecoder);
                }
                else
                {
                    //按点击量排序
                    dt = cs.GetCarsBySql(sql, " Click  desc", pageIndex, pageSize, ref totalrecoder);

                }

                cars = new List<Car>();
                if (dt!=null&&dt.Rows.Count>0)
                {
                    foreach (System.Data.DataRow dr in dt.Rows)
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
            catch (Exception)
            {
                throw;
            }

            return cars;
        }

        public List<Car> GetCarsBySql(int pageIndex,int pageSize,ref int totalrecode)
        {
            List<Car> cars = null;
            System.Data.DataTable dt = new System.Data.DataTable();

            string sql = "select CarId,CarName,Brand.BrandId,BrandName,Picture,OffcialPrice,Click from Car,Brand where Car.BrandId=Brand.BrandId";

            try
            {
                dt = cs.GetCarsBySql(sql, " CarId ", pageIndex, pageSize, ref totalrecode);
                cars = new List<Car>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow dr in dt.Rows)
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
            catch (Exception)
            {
                throw;
            }
            return cars;

          


        }

     }
}
