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

    }
}
