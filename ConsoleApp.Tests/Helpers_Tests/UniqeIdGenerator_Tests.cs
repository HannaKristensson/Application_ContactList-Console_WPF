
using Buisness.Helpers;

namespace MainApp.Tests.Helpers_Tests;

public class UniqeIdGenerator_Tests
{
    [Fact]
    public void CenerateUniqeId_ShouldReturnGuidAsString()
    {
        //act
        var result = UniqeIdGenerator.GenerateUniqeId();

        //assert
        Assert.True(Guid.TryParse(result, out _));
    }
}
