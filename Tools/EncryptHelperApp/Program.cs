using System;
using System.Configuration;
using System.Linq;

namespace EncryptHelperApp
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Data Source:");
			var dataSource = Console.ReadLine();

			Console.WriteLine("Initial Catalog:");
			var initialCatalog = Console.ReadLine();

			Console.WriteLine("User ID:");
			var userID = Console.ReadLine();

			Console.WriteLine("Password:");
			var password = Console.ReadLine();

			(new Worker(string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", dataSource, initialCatalog, userID, password))).ToWrite();
		}
	}
}
