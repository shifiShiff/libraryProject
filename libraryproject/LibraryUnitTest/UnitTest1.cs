using Library.Controllers;
using Library.Modals;
using Microsoft.AspNetCore.Mvc;

namespace LibraryUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Book_Get()
        {
            //Act
            var controller= new BookController();
            var res= controller.Get();

            //Asset
            Assert.IsType<List<Book>>(res);
        }

        [Fact]
        public void Book_GetByID()
        {
            //Arrange
            var id = 3;
            //Act
            var controller = new BookController();
            var res = controller.Get(id);

            //Asset
            Assert.IsType<OkObjectResult>(res);
        }

        [Fact]
        public void Subscribe_GetIDByName()
        {
            //Arrange
            var name= "Shifi Shiff";
            //Act
            var controller = new SubscribeController();
            var res = controller.Get(name);

            //Asset
            Assert.Equal("214860728",res);
        }
    }
}