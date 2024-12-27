

using Buisness.Interfaces;
using Moq;

namespace MainApp.Tests.Services_Tests;

public class FileService_Tests
{

    public readonly Mock<IFileService> _fileServiceMock;
    public readonly IFileService _fileService;

    public FileService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _fileService = _fileServiceMock.Object;
    }



    [Fact]
    public void SaveListToFile_ShouldReturnTrue_WhenListIsAdded()
    {
        //arrange
        _fileServiceMock.Setup(fileService => fileService.SaveListToFile(It.IsAny<string>())).Returns(true);

        //Act 
        var result = _fileService.SaveListToFile("");

        //assert
        Assert.True(result);
    }



    [Fact]
    public void GetListFromFile_ShouldReturnContentOfString_WhenSuccesful()
    {
        //arrange
        _fileServiceMock.Setup(fileService => fileService.GetListFromFile()).Returns("");

        //Act 
        var result = _fileService.GetListFromFile();

        //assert
        Assert.Equal("", result);
    }
}



//arrange
//Act 
//assert