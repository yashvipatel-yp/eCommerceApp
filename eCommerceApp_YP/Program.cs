using System;

namespace eCommerceApp_YP
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var product = new Product(1, "Smartphone", 999.49m, 100);

                ProductDetails(product);

                // Increase stock
                product.IncreaseStock(5);
                Console.WriteLine("\n Increasing 5 units.");
                ProductDetails(product);

                // Decrease stock
                product.DecreaseStock(2);
                Console.WriteLine("\n Decreasing 2 units.");
                ProductDetails(product);

                // Attempt to decrease stock beyond available amount
                Console.WriteLine("\nAttempting to decrease stock by 150 units...");
                product.DecreaseStock(150);
            }
            catch (Exception exception) when (exception is ArgumentOutOfRangeException || exception is InvalidOperationException)
            {
                Console.WriteLine($"Error: {exception.Message}");
            }
        }

        private static void ProductDetails(Product product)
        {
            Console.WriteLine($"Product ID: {product.ProductID}, Product: {product.ProductName}, Price: {product.Price:C}, Current Stock: {product.Stock}");
        }
    }
}