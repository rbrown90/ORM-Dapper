using System;
using System.Data;
using Dapper;
using System.Collections.Generic;

namespace ORM_Dapper
{
	public class DapperProductRepository : IProductRepositoryInterface
	{
        private readonly IDbConnection _connection;

		public DapperProductRepository(IDbConnection connection)
		{
            _connection = connection;
		}

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products");
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO PRODUCT (Name, Price, CategoryID)" +
                "VALUES (@product, @price, @categoryID);",
                new { name = name, price = price, categoryID = categoryID });
        }

        public void UpdateProduct(string updatedName, int productID)
        {
            _connection.Execute("UPDATE product SET Name = updatedName WHERE @productID = productID",
                new { name = updatedName, productID = productID  });
        }
    }
}

