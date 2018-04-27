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
        public void Constructor_CreatesAReviewObject_True()
        {
            //Arrange
            var review = new Review();

            //Act

            //Assert
            Assert.IsInstanceOfType(review, typeof(Review));
        }

        [TestMethod]
        public void Equals_ReviewsWithSameIdAreEqual_True()
        {
            //Arrange 
            var review1 = new Review();
            review1.ReviewId = 1;

            var review2 = new Review();
            review2.ReviewId = 1;

            //Act


            //Assert
            Assert.AreEqual(review1, review2);
        }

        [TestMethod]
        public void VerifyRating_RatingIsBetweenOneAndFive_True()
        {
            //Act
            var review = new Review();
            review.Rating = 4;

            //Act
            var result = review.VerifyRating();

            //Assert
            Assert.AreEqual(true, result);

        }
    }
}
