using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);


            var repo = new DapperProductRepository(conn);

            Console.WriteLine("What is the new product name?");
            var prodName = Console.ReadLine();

            Console.WriteLine("What is the product price?");
            var prodPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("What is the Product categoryID?");
            var prodCategoryID = int.Parse(Console.ReadLine());

            repo.CreateProduct(prodName, prodPrice, prodCategoryID);

            var prodList = repo.GetAllProducts();

            foreach (var prod in prodList)
            {
                Console.WriteLine($"{prod.ProductID} - {prod.Name}");
            }

            Console.WriteLine("What is the productID of the product you want to update?");
            var prodID = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the name you wish to update the product to");
            var prodNewName = Console.ReadLine();

            repo.UpdateProduct(prodNewName, prodID);
        }
    }
}
