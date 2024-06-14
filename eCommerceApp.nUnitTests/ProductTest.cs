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

    }
}