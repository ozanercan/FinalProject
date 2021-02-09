using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetProducts();

            //GetCategories();

            IProductService productService = new ProductManager(new EfProductDal());

            var productDetails = productService.GetProductDetails();

            productDetails.ForEach(p =>
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Product Id: {p.ProductID} \nCategory: {p.CategoryName}\nProduct: {p.ProductName}\nStock: {p.UnitsInStock}");
            });

            Console.ReadLine();
        }

        private static void GetCategories()
        {
            ICategoryService categoryService = new CategoryManager(new EfCategoryDal());

            var categories = categoryService.GetAll();

            categories.ForEach(category => Console.WriteLine(category.CategoryName));
        }

        private static void GetProducts()
        {
            IProductService productService = new ProductManager(new EfProductDal());

            var productList = productService.GetAllByCategoryId(2);

            productList.ForEach(p => Console.WriteLine(p.ProductName));
        }
    }
}
