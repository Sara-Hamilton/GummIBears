using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBears.Models;

namespace GummiBears.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void GetName_ReturnsProductName_String()
        {
            //Arrange
            var product = new Product();
            product.Name = "Giant Gummy Bear";

            //Act
            var result = product.Name;

            //Assert
            Assert.AreEqual("Giant Gummy Bear", result);
        }

        [TestMethod]
        public void GetDescription_ReturnsProductDescription_String()
        {
            //Arrange
            var product = new Product();
            product.Description = "16 oz. gummy bear";

            //Act
            var result = product.Description;

            //Assert
            Assert.AreEqual("16 oz. gummy bear", result);
        }

        [TestMethod]
        public void GetCost_ReturnsProductCost_Decimal()
        {
            //Arrange
            var product = new Product();
            product.Cost = 2.99m;

            //Act
            var result = product.Cost;

            //Assert
            Assert.AreEqual(2.99m, result);
        }

        [TestMethod]
        public void GetImageUrl_ReturnsProductImageUrl_String()
        {
            //Arrange
            var product = new Product();
            product.ImageUrl = "https://i.ytimg.com/vi/1CbfG0epWHo/maxresdefault.jpg";

            //Act
            var result = product.ImageUrl;

            //Assert
            Assert.AreEqual("https://i.ytimg.com/vi/1CbfG0epWHo/maxresdefault.jpg", result);
        }

        [TestMethod]
        public void GetProductId_ReturnsProductId_Int()
        {
            //Arrange
            var product = new Product();
            product.ProductId = 1;

            //Act
            var result = product.ProductId;

            //Assert
            Assert.AreEqual(1, result);
        }

    }
}
