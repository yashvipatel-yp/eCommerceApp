using NUnit.Framework;
using System;
using global::eCommerceApp_YP;

namespace eCommerceApp.nUnitTests
{
    [TestFixture]
    public class ProductTests
    {
        // ProductID tests
        [Test]
        public void ProductID_Valid_ShouldCreate()
        {
            // Arrange
            int productId = 1;
            string productName = "Smartphone";
            decimal price = 100;
            int stock = 10;

            // Act
            var product = new Product(productId, productName, price, stock);

            // Assert
            Assert.That(product.ProductID, Is.EqualTo(productId));
        }

        [Test]
        public void ProductID_OutOfRange_ShouldThrow()
        {
            // Arrange
            int productId = 0;
            string productName = "Smartphone";
            decimal price = 100;
            int stock = 10;

            // Act & Assert
            Assert.That(() => new Product(productId, productName, price, stock), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void ProductID_Max_ShouldCreate()
        {
            // Arrange
            int productId = 10000;
            string productName = "Smartphone";
            decimal price = 100;
            int stock = 10;

            // Act
            var product = new Product(productId, productName, price, stock);

            // Assert
            Assert.That(product.ProductID, Is.EqualTo(productId));
        }

        // ProductName tests
        [Test]
        public void ProductName_Valid_ShouldCreate()
        {
            // Arrange
            int productId = 1;
            string productName = "Laptop";
            decimal price = 100;
            int stock = 10;

            // Act
            var product = new Product(productId, productName, price, stock);

            // Assert
            Assert.That(product.ProductName, Is.EqualTo(productName));
        }

        [Test]
        public void ProductName_Null_ShouldThrow()
        {
            // Arrange
            int productId = 1;
            string productName = null;
            decimal price = 100;
            int stock = 10;

            // Act & Assert
            Assert.That(() => new Product(productId, productName, price, stock), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ProductName_Empty_ShouldThrow()
        {
            // Arrange
            int productId = 1;
            string productName = "";
            decimal price = 100;
            int stock = 10;

            // Act & Assert
            Assert.That(() => new Product(productId, productName, price, stock), Throws.TypeOf<ArgumentNullException>());
        }

        // Price tests
        [Test]
        public void Price_Valid_ShouldCreate()
        {
            // Arrange
            decimal price = 100;

            // Act
            var product = new Product(1, "Smartphone", price, 10);

            // Assert
            Assert.That(product.Price, Is.EqualTo(price));
        }

        [Test]
        public void Price_OutOfRange_ShouldThrow()
        {
            // Arrange
            decimal price = 5001;

            // Act & Assert
            Assert.That(() => new Product(1, "Smartphone", price, 10), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Price_Max_ShouldCreate()
        {
            // Arrange
            decimal price = 5000;

            // Act
            var product = new Product(1, "Smartphone", price, 10);

            // Assert
            Assert.That(product.Price, Is.EqualTo(price));
        }

        // Stock tests
        [Test]
        public void Stock_Valid_ShouldCreate()
        {
            // Arrange
            int stock = 10;

            // Act
            var product = new Product(1, "Smartphone", 100, stock);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(stock));
        }

        [Test]
        public void Stock_OutOfRange_ShouldThrow()
        {
            // Arrange
            int stock = 100001;

            // Act & Assert
            Assert.That(() => new Product(1, "Smartphone", 100, stock), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Stock_Max_ShouldCreate()
        {
            // Arrange
            int stock = 100000;

            // Act
            var product = new Product(1, "Smartphone", 100, stock);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(stock));
        }


        // IncreaseStock tests
        [Test]
        public void IncreaseStock_Valid_ShouldIncrease()
        {
            // Arrange
            var product = new Product(1, "Smartphone", 100, 10);
            int increaseAmount = 5;

            // Act
            product.IncreaseStock(increaseAmount);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(15));
        }

        [Test]
        public void IncreaseStock_Invalid_ShouldThrow()
        {
            // Arrange
            var product = new Product(1, "Smartphone", 100, 10);
            int increaseAmount = -5;

            // Act & Assert
            Assert.That(() => product.IncreaseStock(increaseAmount), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void IncreaseStock_Max_ShouldNotThrow()
        {
            // Arrange
            var product = new Product(1, "Smartphone", 100, 100000);
            int increaseAmount = 1;

            // Act & Assert
            Assert.That(() => product.IncreaseStock(increaseAmount), Throws.Nothing);
        }

        // DecreaseStock tests
        [Test]
        public void DecreaseStock_Valid_ShouldDecrease()
        {
            // Arrange
            var product = new Product(1, "Smartphone", 100, 10);
            int decreaseAmount = 5;

            // Act
            product.DecreaseStock(decreaseAmount);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(5));
        }

        [Test]
        public void DecreaseStock_Invalid_ShouldThrow()
        {
            // Arrange
            var product = new Product(1, "Smartphone", 100, 10);
            int decreaseAmount = -5;

            // Act & Assert
            Assert.That(() => product.DecreaseStock(decreaseAmount), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void DecreaseStock_TooMuch_ShouldThrow()
        {
            // Arrange
            var product = new Product(1, "Smartphone", 100, 10);
            int decreaseAmount = 15;

            // Act & Assert
            Assert.That(() => product.DecreaseStock(decreaseAmount), Throws.TypeOf<InvalidOperationException>());
        }
    }
}