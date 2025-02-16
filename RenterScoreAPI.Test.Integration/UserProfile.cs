using System.Net;
using System.Net.Http.Headers;
using NuGet.Frameworks;

namespace RenterScoreAPI.Test.Integration;

public class UserProfile
{
    private HttpClient client;

    [SetUp]
    public void Setup()
    {
        client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5135/user profile");
    }

    [TearDown]
    public void TearDown()
    {
        client.Dispose();
    }

    [Test]
    public async Task Get()
    {
        var response = await client.GetAsync("");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task Post()
    {
        var content = new StringContent($@"
        {{
            ""id"": ""{Guid.NewGuid()}"",
            ""name"": ""string"",
            ""email"": ""string""
        }}
        ");
        content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        var response = await client.PostAsync("", content);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
    }
}