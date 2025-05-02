// using NUnit.Framework;
// using RestSharp;
// using System.Threading.Tasks;

// namespace RestSharpApi
// {
//     public class PutTests
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
//         public async Task UpdateUser_ReturnsSuccess()
//         {
//             var request = new RestRequest("/api/users/2", Method.Put);
//             request.AddJsonBody(new
//             {
//                 name = "morpheus",
//                 job = "zion resident"
//             });

//             var response = await _client.ExecuteAsync(request);

//             Assert.That(response.IsSuccessful, Is.True, "PUT Response was not successful");
//             TestContext.WriteLine(response.Content);
//         }
//     }
// }
using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;

namespace RestSharpApi
{
    public class PutTests
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
        public async Task UpdateUser_ReturnsSuccess()
        {
            var request = new RestRequest("/api/users/2", Method.Put);

        
            request.AddHeader("x-api-key", "reqres-free-v1");
            request.AddHeader("Accept", "application/json");

            request.AddJsonBody(new
            {
                name = "morpheus",
                job = "zion resident"
            });

            var response = await _client.ExecuteAsync(request);

            Assert.That(response.IsSuccessful, Is.True, "PUT Response was not successful");
            TestContext.WriteLine(response.Content);
        }
    }
}
