using System;
using Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe_TestMethods
{
    [TestClass]
    public class MenuRepoTests
    {
        private MenuRepo _repo;
        private MenuClass _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepo();
            _content = new MenuClass(10, "Taco", "Traditional taco with cheese, lettuce, tomato, and sour cream", "Meat, cheese, lettuce, tomato, sour cream", 4.99m);

            _repo.AddToMenu(_content);
        }

        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            //Arrange
            MenuClass menu = new MenuClass();
            menu.ID = 10;
            MenuRepo _menuRepo = new MenuRepo();

            //Act
            _menuRepo.AddToMenu(menu);
            MenuClass itemFromDirectory = _menuRepo.GetItemByID(10);

            //Assert
            Assert.IsNotNull(itemFromDirectory);
        }

        [TestMethod]
        public void UpdateMenu_ShouldReturnTrue()
        {
            //Arrange
            //Test Initialize
            MenuClass newMenuItem = new MenuClass(7, "Taco", "Traditional taco with cheese, lettuce, tomato, and sour cream", "Meat, cheese, lettuce, tomato, sour cream", 6.99m);


            //Act
            bool updateResult = _repo.UpdateMenuItem(10, newMenuItem);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            //Arrange
            //Act
            bool deleteResult = _repo.RemoveMenuItem(_content.ID);

            //Assert
            Assert.IsTrue(deleteResult);
        }
    }

}

         
            
