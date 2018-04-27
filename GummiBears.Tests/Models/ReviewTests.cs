using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBears.Models;
using System.Collections.Generic;
using System.Linq;

namespace GummiBears.Tests
{
    [TestClass]
    public class ReviewTests
    {
        [TestMethod]
        public void Constructor_CreatesAProductObject_True()
        {
            //Arrange
            var review = new Review();

            //Act

            //Assert
            Assert.IsInstanceOfType(review, typeof(Product));
        }
    }
}
