//using Library.Api.Controllers;
//using Library.Core.Modals;
//using Library.Core.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace LibraryUnitTest
//{
//    //public class UnitTest1
    //{
    //    [Fact]
    //    public void Book_Get()
    //    {
    //        //Act
    //        var controller = new BookController(new FakeData());
    //        var res= controller.Get();

    //        //Asset
    //        Assert.IsType<List<Book>>(res);
    //    }

    //    //[Fact]
    //    //public void Book_GetByID()
    //    //{
    //    //    //Arrange
    //    //    var id = 1;
    //    //    //Act
    //    //    var controller = new BookController(new FakeData());
    //    //    var res = controller.Get(id);

    //    //    //Asset
    //    //    Assert.IsType<OkObjectResult>(res);
    //    //}


    //    [Fact]
    //    public void Book_GetByIDNotFound()
    //    {
    //        //Arrange
    //        var id = 5;
    //        //Act
    //        var controller = new BookController(new FakeData());
    //        var res = controller.Get(id);

    //        //Asset
    //        Assert.IsType<NotFoundResult>(res);
    //    }

    //    [Fact]
    //    public void Subscribe_GetIDByName()
    //    {
    //        //Arrange
    //        var name= "Shifi Shiff";
    //        //Act
    //        var controller = new SubscribeController(new FakeData());
    //        var res = controller.Get(name);

    //        //Asset
    //        Assert.Equal("214860728",res);
    //    }

    //}
//}