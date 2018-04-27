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

    }
}
