using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Interfaces;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Adapters;
using Project0.StoreApplication.Storage.Models;
using Project0.StoreApplication.Storage.Models.Mapping;

namespace Project0.StoreApplication.Storage.Repositories
{
  /// <summary>
  /// 
  /// </summary>
  public class ProductRepository : IRepository<Product_D>
  {
    private const string _path = @"/home/clypto/revature/training_code/projects/data/products.xml";
        private static readonly ProductMapper _productMapper = ProductMapper.Instance;
        private static readonly StoreApplicationDBContext saDBContext = new StoreApplicationDBContext();

        public List<Product_D> Products { get; private set; }

        public ProductRepository()
    {
      //if (_fileAdapter.ReadFromFile<Product_D>(_path) == null)
      //{
      //  _fileAdapter.WriteToFile<Product_D>(_path, new List<Product_D>()
      //  {
      //    new Product_D("Generic CPU", 59.99m, 1),
      //    new Product_D("Generic GPU", 100.00m, 1),
      //    new Product_D("Super Fancy Case", 1000.00m, 1),

      //    new Product_D("Pack of Ballpoint Pens", 5.00m, 2),
      //    new Product_D("One of those fancy pens that you dip in ink", 5000.00m, 2),

      //    new Product_D("CD that catches on fire if you use it", 5.55m, 3),
      //    new Product_D("Broken pair of branded headphones", 150.00m, 3)


      //  });
      }

        private static ProductRepository _productRepository;

        public static ProductRepository GetInstance()
        {

            if (_productRepository == null)
            {
                _productRepository = new ProductRepository();
            }

            return _productRepository;
        }

        public async Task<List<Product_D>> SelectProductByStoreIDAsync(int i)
        {
                     
            //create a list of products based on store ID
            List<Product> c1 = await saDBContext.Products.FromSqlRaw("SELECT * FROM Product").ToListAsync();

            //Swap each list element to local model 
            List<Product_D> c2 = new List<Product_D>();
            foreach(Product p in c1)
            {
                if(p.StoreId == i)
                {
                    Product_D p2 = _productMapper.ModelToViewModel(p);
                    c2.Add(p2);
                }
            }

            //check if null
            if (c2 == null) return null;           
            return c2;
        }

        public bool Delete(Product_D entry)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Product_D entry)
        {
            throw new System.NotImplementedException();
        }

        public Product_D Update(Product_D entry)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Product_D>> Select()
        {
            return Products;
        }
    }
}