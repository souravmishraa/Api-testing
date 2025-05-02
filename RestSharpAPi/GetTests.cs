using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;

namespace RestSharpApi
{
    public class GetTests
    {
        private RestClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new RestClient("https://reqres.in/api");
        }

        [TearDown]
        public void TearDown()
        {
            _client?.Dispose();
            _client = null;
        }

        [Test]
        public async Task GetUsers_ReturnsSuccess()
        {
            var request = new RestRequest("users?page=2", Method.Get);
            var response = await _client.ExecuteAsync(request);

            Assert.That(response.IsSuccessful, Is.True, "API Response was not successful!");
            TestContext.WriteLine(response.Content);
        }
    }
}
