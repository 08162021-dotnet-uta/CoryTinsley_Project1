using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Interfaces;



namespace Project0.StoreApplication.Storage.Models.Mapping
{
    class ProductMapper : IModelMapper<Product, Product_D>
    {
        public static ProductMapper _productMapper;
        public static ProductMapper Instance
        {
            get
            {
                if (_productMapper == null)
                {
                    _productMapper = new ProductMapper();
                }


                return _productMapper;
            }
        }
        public Product_D ModelToViewModel(Product entry)
        {
            Product_D c = new Product_D();
            c.Price = entry.Price;
            c.Name = entry.Name;
            c.ProductKey = entry.ProductId;
            c.StoreID = entry.StoreId;
            c.Quantity = entry.Quantity;
            return c;
        }

        public Product ViewModelToModel(Product_D entry)
        {
            Product c = new Product();
            c.Name = entry.Name;
            c.Quantity = entry.Quantity;
            c.Price = entry.Price;
            return c;
        }
    }//EOC
}//EON
