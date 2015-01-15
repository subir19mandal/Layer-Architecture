using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductEntryApp.DAL.DAO;
using ProductEntryApp.DAL.DBGateway;

namespace ProductEntryApp.BLL
{
    internal class ProductManager
    {
        private const int MIN_LENGTH_Of_CODE = 3;
        private ProductDbGateway aProductDbGateway = new ProductDbGateway();

        public string Save(Product aProduct)
        {
            if (aProduct.ProductCode.Length >= MIN_LENGTH_Of_CODE && aProduct.Quantity >= 0)
            {
                if (aProductDbGateway.HasProductCode(aProduct.ProductCode) ==null)
                {
                   aProductDbGateway.Save(aProduct);
                   return "Saved";
                }

            else
                {
                   aProductDbGateway.Update(aProduct);
                   return "Updated";
                }
            }
            else
            {
                return "ProductCode must be " + MIN_LENGTH_Of_CODE + " desigt long and Qunatinty must be possitive!!!";
            }
        }

        public List<Product> GetAll()
        {
            return aProductDbGateway.GetAll();
        }

      public int GetTotalQuantity()
        {
            return aProductDbGateway.GetTotalQuantity();
        }
        
        }
    }

     
