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

            //Act
            var result = product.Name;

            //Assert
            Assert.AreEqual("Giant Gummy Bear", result);
        }
    }
}
