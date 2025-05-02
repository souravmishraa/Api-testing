using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;
 
namespace RestSharpApi
{
    public class UnitTest1
    {
        private RestClient _client;
 
        [SetUp]
        public void Setup()
        {
            _client = new RestClient("https://jsonplaceholder.typicode.com");
        }
 
        [TearDown]
        public void TearDown()
        {
            _client?.Dispose();
            _client = null;
        }
 
        [Test]
        public async Task GetPosts_ReturnsSuccess()
        {
            var request = new RestRequest("posts", Method.Get);
            var response = await _client.ExecuteAsync(request);
 
            Assert.That(response.IsSuccessful, Is.True);
            TestContext.WriteLine(response.Content);
        }
    }
}
 