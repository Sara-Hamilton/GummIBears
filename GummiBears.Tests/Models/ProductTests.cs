using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBears.Models;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void Equals_ProductsWithSameIdAreEqual_True()
        {
            //Arrange 
            var product1 = new Product();
            product1.ProductId = 1;

            var product2 = new Product();
            product2.ProductId = 1;

            //Act
            

            //Assert
            Assert.AreEqual(product1, product2);
        }

        [TestMethod]
        public void AverageReview_ReturnsAverageReviewRating_Decimal()
        {
            //Arrange
            var review1 = new Review();
            review1.Rating = 3;
            var review2 = new Review();
            review2.Rating = 4;
            var product = new Product();
            List<Review> reviews = new List<Review>();
            reviews.Add(review1);
            reviews.Add(review2);
            product.Reviews = reviews;

            //Act
            var result = product.AverageReview();

            //Assert
            Assert.AreEqual(3.5m, result);
        }

        [TestMethod]
        public void AverageReviewWithProductId_ReturnsAverageReviewRating_Decimal()
        {
            //Arrange
            var review1 = new Review();
            review1.ProductId = 1;
            review1.Rating = 3;
            var review2 = new Review();
            review2.ProductId = 1;
            review2.Rating = 4;
            var product = new Product();
            List<Review> reviews = new List<Review>();
            reviews.Add(review1);
            reviews.Add(review2);
            product.Reviews = reviews;

            //Act
            var result = product.AverageReview(1);

            //Assert
            Assert.AreEqual(3.0m, result);
        }

        [TestMethod]
        public void Constructor_CreatesAProductObject_True()
        {
            //Arrange
            var product = new Product();

            //Act

            //Assert
            Assert.IsInstanceOfType(product, typeof(Product));
        }

    }
}
