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