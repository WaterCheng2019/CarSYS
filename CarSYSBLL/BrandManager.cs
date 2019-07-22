using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSYSModels;
using CarSYSDAL;

namespace CarSYSBLL
{
    public class BrandManager
    {
        BrandService bs = new BrandService();

        public List<Brand> GetBrands()
        {
            try
            {
                return bs.GetBrnads();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddBrand(Brand b)
        {
 
            bs.AddBrand(b);


        }

        public int DelBrandById(int BrandId)
        {
            try
            {
                return bs.DelBrandById(BrandId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Brand GetBrandById(int BrandId)
        {
            return bs.GetBrandById(BrandId);
        }

        public int UpdateBrandById(Brand b)
        {
            return bs.UpdateBrandById(b);
        }

    }
}
