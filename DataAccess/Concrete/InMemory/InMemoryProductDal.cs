using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> { 
                new Product{ProductID=1, CategoryID=1, ProductName="Bardak", UnitInStock= 15, UnitPrice=15},
                new Product{ProductID=2, CategoryID=1, ProductName="Kamera", UnitInStock= 500, UnitPrice=3},
                new Product{ProductID=3, CategoryID=2, ProductName="Telefon", UnitInStock= 1500, UnitPrice=2},
                new Product{ProductID=4, CategoryID=2, ProductName="Klavye", UnitInStock= 150, UnitPrice=65},
                new Product{ProductID=5, CategoryID=2, ProductName="Mause", UnitInStock= 85, UnitPrice=1},
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete /*= null*/;
            /*foreach (var pr in _products)
            {
                if (product.ProductID == pr.ProductID)
                {
                    productToDelete = pr;
                }
            }*/
            //Foreach ile dögüye sokmak yerine LİNQ kullanılır.
            //Her pr için git ve pr nin product ıd si, parametre gönderilen product id ye eşit mi.?
            productToDelete = _products.SingleOrDefault(pr => pr.ProductID == product.ProductID);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCatagory(int catagoryID)
        {
           return _products.Where(pr => pr.CategoryID == catagoryID).ToList();
        }

        public void Update(Product product)
        {
            //GÖderilen ürün id sine sahip olan, listedeki ürünü bul ve güncelle.
            Product productToUpdate = _products.SingleOrDefault(pr => pr.ProductID == product.ProductID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;

        }
    }
}
