using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTUS_C_.Basic._17
{
	public class Customer
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
		public override string ToString()
		{
			return $"{ID} - {FirstName} {LastName}, Age: {Age}";
		}
    }

	public class Product
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int StockQuantity { get; set; }
		public decimal Price { get; set; }

		public override string ToString()
		{
			return $"{ID} - {Name}: {Description}, Stock: {StockQuantity}, : {Price}";
		}
	}

	public class Order
	{
		public int ID { get; set; }
		public int CustomerID { get; set; }
		public int ProductID { get; set; }
		public int Quantity { get; set; }
		public override string ToString()
		{
			return $"Order ID: {ID}, Customer ID: {CustomerID}, Product ID: {ProductID}, Quantity: {Quantity}";
		}
    }

}
