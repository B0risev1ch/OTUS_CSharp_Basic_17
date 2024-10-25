using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace OTUS_C_.Basic._17
{
    class DBHelper
    {
	   private NpgsqlConnection? connection;
        public DBHelper(string connectionString)
        {
            try
            {
                Console.WriteLine($"Подключаюсь... {connectionString}");
                this.connection = new NpgsqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Не удалось подключиться по {connectionString}:\n{e.Message}");
            }

            if (connection != null)
            {
                Console.WriteLine($"Подключились...\n\tDataSource = {connection.DataSource}" +
                                  $"\n\tDatabase = {connection.Database}" + 
                                  $"\n\tFullState = {connection.FullState}"
                );
                if (connection.FullState == ConnectionState.Closed)
                {
                    Console.WriteLine($"Соединение закрыто. Открываю");

                    try
                    {
                        connection.Open();
                        Console.WriteLine($"Соединение открыто");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Не удалось открыть соединение\n" +
                                          $"FullState = {connection.FullState}" + $"\n{e.Message}");
                    }
                }

            }
        }

        public List<Customer> GetCustomersOlderThan(int age)
        {
	        if (connection != null)
	        {
		        return connection.Query<Customer>("SELECT * FROM Customers WHERE Age > @Age", new { Age = age }).ToList();
	        }

	        return new List<Customer>();
        }
        public List<Order> GetOrderByProductID(int productId)
        {
	        if (connection != null)
	        {
		        return connection.Query<Order>("SELECT * FROM Orders WHERE ProductID = @ProductID",
			        new { ProductID = productId }).ToList();

	        }
	        return new List<Order>();
        }

        public List<Customer> GetCustomers()
        {
	        if (connection != null)
	        {
		        return connection.Query<Customer>("SELECT * FROM Customers").ToList();
            }

	        return new List<Customer>();
        }
        public List<Order> GetOrders()
        {
	        if (connection != null)
	        {
		        return connection.Query<Order>("SELECT * FROM Orders").ToList();
	        }

	        return new List<Order>();
        }
        public List<Product> GetProducts()
        {
	        if (connection != null)
	        {
		        return connection.Query<Product>("SELECT * FROM Products").ToList();
	        }

	        return new List<Product>();
        }
    }

}
