using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Client.Singletons
{

  public class ProductSingleton
  {

    private static ProductSingleton _productSingleton;
    private static readonly ProductRepository _productRepository = new ProductRepository();
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;

    public List<Product_D> Products { get; set; }

    public static ProductSingleton Instance
    {
      get
      {

        if (_productSingleton == null)
          _productSingleton = new ProductSingleton();

        return _productSingleton;

      }
    }

    private ProductSingleton()
    {
      //Products = _productRepository.Select();

    }


    /// <summary>
    /// Sorts items into proper store List<>
    /// </summary>
    /// <param name="stores"></param>
    /// <returns></returns>
    public List<Product_D> SortProducts(Store_D store)
    {
      List<Product_D> localProduct = new List<Product_D>();

      foreach (Product_D p in Products)
      {
        if (p.StoreID == store.StoreID)
          localProduct.Add(p);

      }

      return localProduct;
    }


    /// <summary>
    /// Adds new product to repository
    /// </summary>
    /// <param name="product"></param>
    public void Add(Product_D product)
    {

      _productRepository.Insert(product);
      //Products = _productRepository.Select();

    }

  }
}