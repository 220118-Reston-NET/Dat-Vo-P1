using Xunit;

namespace Project0;
public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //Arrange
        string expected = "55";

        //Act
        string actual = "55";

        //Assert
        Assert.Equal(expected, actual);
    }
}