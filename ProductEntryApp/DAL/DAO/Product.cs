using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductEntryApp.DAL.DAO
{
   public class Product
    {
        public string ProductCode { set; get; }
        public string Description { set; get; }
        public int Quantity { set; get; }
    }
}
