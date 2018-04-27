using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GummiBears.Models;
using Moq;
using System.Linq;
using System;
using GummiBears.Controllers;

namespace GummiBears.Tests.ControllerTests
{
    [TestClass]
    public class ReviewsControllerTest
    {
        Mock<IProductRepository> productMock = new Mock<IProductRepository>();
        Mock<IReviewRepository> reviewMock = new Mock<IReviewRepository>();

        private void DbSetup()
        {
            productMock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product { ProductId = 1, Name = "Giant Gummi", Description = "12 oz. gummi bear", Cost = 4.99m, ImageUrl = "https://i.ytimg.com/vi/1CbfG0epWHo/maxresdefault.jpg" },
            new Product { ProductId = 2, Name = "Green Gummies", Description = "16 oz. bag  of green gummi bears", Cost = 6.49m, ImageUrl = "https://www.ilovesugar.com/images/Green-Apple-Gummy-Bears-Candy.jpg" },
            new Product { ProductId = 3, Name = "Glitter Gummies", Description = "16 oz. bag  of pink and purple glittery gummi bears", Cost = 8, ImageUrl = "https://img0.etsystatic.com/165/1/8581691/il_340x270.1095861008_ny4h.jpg" },
            }.AsQueryable());

            reviewMock.Setup(m => m.Reviews).Returns(new Review[]
            {
                new Review { ReviewId = 1, Title = "Love It!", Author = "Sara", Content_Body = "This is the best gummy bear I have ever had.", Rating = 5, ProductId = 1},
                new Review { ReviewId = 2, Title = "Yummy Gummy", Author = "Jim", Content_Body = "This is great.  You should buy it.", Rating = 5, ProductId = 1},
                new Review { ReviewId = 3, Title = "Meh", Author = "Megan", Content_Body = "These are OK.  I've had better", Rating = 3, ProductId = 3},
                new Review { ReviewId = 4, Title = "Go Glitter!", Author = "Kevin", Content_Body = "Everything's better with glitter.  These gummy bears are no exception.", Rating = 3, ProductId = 3},
                new Review { ReviewId = 5, Title = "Gross", Author = "Jake", Content_Body = "Who wants to eat glitter?", Rating = 1, ProductId = 3},
                new Review { ReviewId = 6, Title = "Great Green Gummies", Author = "George", Content_Body = "These are great.  i can't stop eating them.", Rating = 5, ProductId = 3},
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult()
        {
            //Arrange
            DbSetup();
            ReviewsController controller = new ReviewsController(reviewMock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List()
        {
            // Arrange
            DbSetup();
            ViewResult indexView = new ReviewsController(reviewMock.Object).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Product>));
        }
    }
}
