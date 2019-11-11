using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1.ProductManagement
{
    class ProductProcess
    {
        ProductDAO dao;
        public ProductProcess()
        {
            dao = new ProductDAO();
        }
        public List<Product> GetProducts(string criteria)
        {
            return dao.GetProducts(criteria);
        }
        public Product GetProduct(int productId)
        {
            return dao.GetProduct(productId);
        }
        public void CreateProduct(Product item)
        {
            dao.CreateProduct(item);
        }
        public void UpdateProduct(Product item)
        {
            dao.UpdateProduct(item);
        }

    }
}