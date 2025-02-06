using Microsoft.AspNetCore.Mvc.Testing;

[TestCaseOrderer("HomeEnergyApi.Tests.Extensions.PriorityOrderer", "HomeEnergyApi.Tests")]
public class HomesControllersTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public HomesControllersTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory, TestPriority(1)]
    [InlineData("/Homes")]
    public async Task HomeEnergyApiReturnsSuccessfulHTTPResponseCodeOnGETHomes(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(url);

        Assert.True(response.IsSuccessStatusCode,
            $"HomeEnergyApi did not return successful HTTP Response Code on GET request at {url}; instead received {(int)response.StatusCode}: {response.StatusCode}");
    }


    [Theory, TestPriority(2)]
    [InlineData("admin/Homes/Location/50313")]
    public async Task ZipLocationServiceRespondsWith200CodeAndPlaceWhenGivenValidZipCode(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.PostAsync(url, null);

        Assert.True((int)response.StatusCode == 200,
             $"HomeEnergyApi did not return \"200: OK\" HTTP Response Code on POST request at {url}; instead received {(int)response.StatusCode}: {response.StatusCode}");

        string responseContent = await response.Content.ReadAsStringAsync();
        bool hasPlace = responseContent.Contains("\"place name\":\"Des Moines\"");
        bool hasState = responseContent.Contains("\"state\":\"Iowa\"");


        Assert.True(hasPlace && hasState,
            $"HomeEnergyApi did not return the expected `place name` and `state` from POST request at {url}\nExpected: `place name` of `Des Moines` and `state` of `Iowa`\nReceived: {responseContent}");
    }
}
