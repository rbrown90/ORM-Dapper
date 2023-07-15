using System;
namespace ORM_Dapper
{
	public interface IProductRepositoryInterface
	{
		public IEnumerable<Product> GetAllProducts();
		void CreateProduct(string name, double price, int categoryID);
		void UpdateProduct(string updatedName, int productID);
	}
}

