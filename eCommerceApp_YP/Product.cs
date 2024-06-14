using System;

namespace eCommerceApp_YP
{
    public class Product
    {
        public int ProductID { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        public Product(int productId, string productName, decimal price, int stock)
        {
            ValidateProductID(productId);
            ValidateProductName(productName);
            ValidatePrice(price);
            ValidateStock(stock);

            ProductID = productId;
            ProductName = productName;
            Price = price;
            Stock = stock;
        }

        private void ValidateProductID(int productId)
        {
            if (productId < 1 || productId > 10000)
                throw new ArgumentOutOfRangeException(nameof(productId), "ProductID must be in the range 1 to 10000.");
        }

        private void ValidateProductName(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentNullException(nameof(productName), "Product name cannot be empty or null.");
        }

        private void ValidatePrice(decimal price)
        {
            if (price < 1 || price > 5000)
                throw new ArgumentOutOfRangeException(nameof(price), "Price must be within the range of 1 to 5000.");
        }

        private void ValidateStock(int stock)
        {
            if (stock < 1 || stock > 100000)
                throw new ArgumentOutOfRangeException(nameof(stock), "Stock level must be between 1 and 100000.");
        }

        public void IncreaseStock(int unit)
        {
            Stock = (unit > 0) ? Stock + unit : throw new ArgumentOutOfRangeException(nameof(unit), "Stock to increase must be positive.");
        }

        public void DecreaseStock(int unit)
        {
            if (unit <= 0)
                throw new ArgumentOutOfRangeException(nameof(unit), "Stock to decrease must be positive.");

            Stock = (unit <= Stock) ? Stock - unit : throw new InvalidOperationException("Insufficient stock to complete the operation.");
        }

    }
}
