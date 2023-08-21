using API.conectionsSpotify;
using Xunit;

public class testclass
{
    [Fact]
    public void TestToken()
    {
        Assert.NotNull(Conection.Token());
    }

    [Fact]
    public void TestGetToken()
    {
        Assert.NotEmpty((System.Collections.IEnumerable)Conection.GetTokenAsync());        
    }

    [Fact]
    public void TestGetListSpotify()
    {
        Assert.NotEmpty((System.Collections.IEnumerable)Conection.SearchSpotify("could"));        
    }


}