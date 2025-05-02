// using NUnit.Framework;
// using RestSharp;
// using System.Threading.Tasks;

// namespace RestSharpApi
// {
//     public class DeleteTests
//     {
//         private RestClient _client;

//         [SetUp]
//         public void Setup()
//         {
//             _client = new RestClient("https://reqres.in");
//         }

//         [TearDown]
//         public void TearDown()
//         {
//             _client?.Dispose();
//             _client = null;
//         }

//         [Test]
//         public async Task DeleteUser_ReturnsSuccess()
//         {
//             var request = new RestRequest("/api/users/2", Method.Delete);

//             var response = await _client.ExecuteAsync(request);

//             Assert.That((int)response.StatusCode, Is.EqualTo(204), "DELETE did not return 204 No Content");
//             TestContext.WriteLine("Delete successful. Status Code: " + (int)response.StatusCode);
//         }
//     }
// }
using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;

namespace RestSharpApi
{
    public class DeleteTests
    {
        private RestClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new RestClient("https://reqres.in");
        }

        [TearDown]
        public void TearDown()
        {
            _client?.Dispose();
            _client = null;
        }

        [Test]
        public async Task DeleteUser_ReturnsSuccess()
        {
            var request = new RestRequest("/api/users/2", Method.Delete);

            request.AddHeader("x-api-key", "reqres-free-v1");
            request.AddHeader("Accept", "application/json");

            var response = await _client.ExecuteAsync(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(204), "DELETE did not return 204 No Content");
            TestContext.WriteLine("Delete successful. Status Code: " + (int)response.StatusCode);
        }
    }
}
