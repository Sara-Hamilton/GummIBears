using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GummiBears.Models;
using Moq;
using System.Linq;
using System;
using GummiBears.Controllers;
using GummiBearKingdom.Controllers;
using GummiBears.Tests.Models;

namespace GummiBears.Tests.ControllerTests
{
    [TestClass]
    public class ProductsControllerTest : IDisposable
    {
        Mock<IProductRepository> mock = new Mock<IProductRepository>();
        EFProductRepository db = new EFProductRepository(new TestDbContext());

        public void Dispose()
        {
            db.DeleteAll();
        }

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
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List()
        {
            // Arrange
            DbSetup();
            ViewResult indexView = new ProductsController(mock.Object).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Product>));
        }

        [TestMethod]
        public void Mock_IndexModelContainsProducts_Collection()
        {
            // Arrange
            DbSetup();
            ProductsController controller = new ProductsController(mock.Object);
            Product testProduct = new Product();
            testProduct.Name = "Giant Gummi";
            testProduct.ProductId = 1;

            // Act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Product> collection = indexView.ViewData.Model as List<Product>;

            // Assert
            CollectionAssert.Contains(collection, testProduct);
        }

        [TestMethod]
        public void Mock_PostViewResultCreate_ViewResult()
        {
            // Arrange
            Product testProduct = new Product
            {
                ProductId = 1,
                Name = "Giant Gummi"
            };

            DbSetup();
            ProductsController controller = new ProductsController(mock.Object);

            // Act
            var resultView = controller.Create(testProduct) as RedirectToActionResult;


            // Assert
            Assert.IsInstanceOfType(resultView, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            // Arrange
            Product testProduct = new Product
            {
                ProductId = 1,
                Name = "Giant Gummi"
            };

            DbSetup();
            ProductsController controller = new ProductsController(mock.Object);

            // Act
            var resultView = controller.Details(testProduct.ProductId) as ViewResult;
            var model = resultView.ViewData.Model as Product;

            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Product));
        }

        [TestMethod]
        public void DB_CreatesNewEntries_Collection()
        {
            // Arrange
            ProductsController controller = new ProductsController(db);
            Product testProduct = new Product();
            testProduct.Description = "TestDb Product";

            // Act
            controller.Create(testProduct);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Product>;

            // Assert
            CollectionAssert.Contains(collection, testProduct);
        }

        [TestMethod]
        public void DB_DbStartsEmpty_0()
        {
            //Arrange
            //Act
            int result = db.Products.ToList().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void DB_EditUpdatesInDatabase_String()
        {
            // Arrange
            Product testProduct = new Product { ProductId = 1, Name = "Giant Gummi", Description = "12 oz. gummi bear", Cost = 4.99m, ImageUrl = "https://i.ytimg.com/vi/1CbfG0epWHo/maxresdefault.jpg" };
            db.Save(testProduct);

            //Act
            testProduct.Name = "Edited Test Product";
            db.Edit(testProduct);

            //Assert
            Assert.AreEqual("Edited Test Product", testProduct.Name);
        }

        [TestMethod]
        public void DB_RemoveDeletesFromDatabase_Void()
        {
            //Arrange
            Product testProduct1 = new Product { ProductId = 1, Name = "Giant Gummi", Description = "12 oz. gummi bear", Cost = 4.99m, ImageUrl = "https://i.ytimg.com/vi/1CbfG0epWHo/maxresdefault.jpg" };
            Product testProduct2 = new Product { ProductId = 2, Name = "Green Gummies", Description = "16 oz. bag  of green gummi bears", Cost = 6.49m, ImageUrl = "https://www.ilovesugar.com/images/Green-Apple-Gummy-Bears-Candy.jpg" };
            db.Save(testProduct1);
            db.Save(testProduct2);

            //Act
            db.Remove(testProduct1);

            //Assert
            Assert.AreEqual(1, db.Products.Count());
        }

        [TestMethod]
        public void DB_DeleteAllDeletesAllProductsFromDatabase_Void()
        {
            //Arrange
            Product testProduct1 = new Product { ProductId = 1, Name = "Giant Gummi", Description = "12 oz. gummi bear", Cost = 4.99m, ImageUrl = "https://i.ytimg.com/vi/1CbfG0epWHo/maxresdefault.jpg" };
            Product testProduct2 = new Product { ProductId = 2, Name = "Green Gummies", Description = "16 oz. bag  of green gummi bears", Cost = 6.49m, ImageUrl = "https://www.ilovesugar.com/images/Green-Apple-Gummy-Bears-Candy.jpg" };
            db.Save(testProduct1);
            db.Save(testProduct2);

            //Act
            db.DeleteAll();

            //Assert
            Assert.AreEqual(1, db.Products.Count());
        }

    }
}
