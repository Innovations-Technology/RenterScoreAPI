using System.Net;
using NuGet.Frameworks;

namespace RenterScoreAPI.Test.Integration;

public class Health
{
    private HttpClient client;

    [SetUp]
    public void Setup()
    {
        client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5135/health");
    }

    [TearDown]
    public void TearDown()
    {
        client.Dispose();
    }

    [Test]
    public async Task HealthCheck()
    {
        var response = await client.GetAsync("");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}