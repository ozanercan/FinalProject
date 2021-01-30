using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductService productService = new ProductManager(new InMemoryProductDal());

            var productList = productService.GetAll();

            productList.ForEach(p => Console.WriteLine(p.ProductName));

            Console.ReadLine();
        }
    }
}
