using OTUS_C_.Basic._17;

string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=sa;Database=shop";

DBHelper dbHelper = new DBHelper(connectionString);

var customers = dbHelper.GetCustomers();
var orders = dbHelper.GetOrders();
var products = dbHelper.GetProducts();

//Simple queries
Console.WriteLine("Customers:\n\t" +
                  string.Join("\n\t", customers));

Console.WriteLine("Products:\n\t" +
                  string.Join("\n\t", products));

Console.WriteLine("Orders:\n\t" +
                  string.Join("\n\t", orders));

Console.Write("Введите минимальный возраст: ");
int minAge = int.Parse(Console.ReadLine());
var customersOlderThan = dbHelper.GetCustomersOlderThan(minAge);

Console.WriteLine($"Покупатели старше {minAge}:\n\t" +
                  string.Join("\n\t", customersOlderThan.Select(customer => $"{customer.ID} - {customer.FirstName} {customer.LastName}, Age: {customer.Age}")));


Console.Write("Введите ID продукта: ");
int productId = int.Parse(Console.ReadLine());
var productsInOrder = dbHelper.GetOrderByProductID(productId);
Console.WriteLine($"Поиск заказа по ID продукта {productId}:\n\t" +
                  string.Join("\n\t", productsInOrder.Select(order =>
		                  $"OrderID: {order.ID}, CustomerID: {order.CustomerID}, Quantity: {order.Quantity}")));

var result = from c in customers
	join o in orders on c.ID equals o.CustomerID
	join p in products on o.ProductID equals p.ID
	where c.Age > minAge && o.ProductID == productId
             select new
	{
		CustomerID = c.ID,
		FirstName = c.FirstName,
		LastName = c.LastName,
		ProductID = p.ID,
		ProductQuantity = o.Quantity,
		ProductPrice = p.Price
	};

Console.WriteLine($"{string.Join("\n", result)}");