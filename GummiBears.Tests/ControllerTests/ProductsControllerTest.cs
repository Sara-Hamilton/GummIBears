using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GummiBears.Models;
using Moq;
using System.Linq;
using System;
using GummiBears.Controllers;
using GummiBearKingdom.Controllers;

namespace GummiBears.Tests.ControllerTests
{
    [TestClass]
    public class ProductsControllerTest
    {
        Mock<IProductRepository> mock = new Mock<IProductRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product { ProductId = 1, Name = "Giant Gummi", Description = "12 oz. gummi bear", Cost = 4.99m, ImageUrl = "https://i.ytimg.com/vi/1CbfG0epWHo/maxresdefault.jpg" },
            new Product { ProductId = 2, Name = "Green Gummies", Description = "16 oz. bag  of green gummi bears", Cost = 6.49m, ImageUrl = "https://www.ilovesugar.com/images/Green-Apple-Gummy-Bears-Candy.jpg" },
            new Product { ProductId = 3, Name = "Glitter Gummies", Description = "16 oz. bag  of pink and purple glittery gummi bears", Cost = 8, ImageUrl = "https://img0.etsystatic.com/165/1/8581691/il_340x270.1095861008_ny4h.jpg" },
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult() 
        {
            //Arrange
            DbSetup();
            ProductsController controller = new ProductsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }


    }
}
