using System;
using System.Collections.Generic;
using System.Linq;
using MVVM_learn.Models.Data;
using MVVM_learn.Models.Entyties;

namespace MVVM_learn.Models
{
    public class DbModel
    {
        private ApplicationContext db = new ApplicationContext();

        public DbModel()
        {
            db.Database.EnsureCreated();
        }

        public bool IsPass(string? Name, string? Password)
        {
            bool checkIsExist = db.User.Any(el => el.UserLogin == Name && el.UserPassword == Password);
            return checkIsExist;
        }

        public string CreateNewProduct(string ID, string name, string description, string Category, string manufacturer, int price, int Discount, int CuantityInStock, string Status)
        {
            string result = "Уже существует";

            bool checkIsExist = db.Product.Any(el => el.ProductName == name);
            if (!checkIsExist)
            {
                Product newProduct = new Product {ProductID = ID, ProductName = name, ProductDescription = description, ProductCategory = Category, ProductManufacturer = manufacturer, ProductCost = price, ProductDiscountAmount = Discount, ProductQuantityInStock = CuantityInStock, ProductStatus = Status };
                db.Product.Add(newProduct);
                db.SaveChanges();
                result = "Успешно";
            }
            return result;
        }

        public string DeleteProduct(string ID)
        {
            string result = "Продукт не найден";

            bool checkIsexist = db.Product.Any(el => el.ProductID == ID);
            if (checkIsexist)
            {
                Product productToDelete = db.Product.Find(ID);
                db.Product.Remove(productToDelete);
                db.SaveChanges();
                result = "Успешно";
            }
            return result;
        }

        public List<Product> GetSpecificProductData()
        {
            return db.Product
                .Select(el => new Product
                {
                    ProductPhoto = el.ProductPhoto,//string
                    ProductName = el.ProductName,//string
                    ProductDescription = el.ProductDescription,//string
                    ProductManufacturer = el.ProductManufacturer,//string
                    ProductCost = el.ProductCost,//int
                    ProductQuantityInStock = el.ProductQuantityInStock,//int
                    ProductID = el.ProductID,//int
                })
            .ToList();
        }

        public List<Order> GetAllOrders()
        {
            return db.Order.ToList();
        }
    }
}
