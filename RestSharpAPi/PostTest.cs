// using NUnit.Framework;
// using RestSharp;
// using System.Threading.Tasks;

// namespace RestSharpApi
// {
//     public class PostTests
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
//         public async Task CreateUser_ReturnsSuccess()
//         {
//             var request = new RestRequest("/api/users", Method.Post);
//             request.AddJsonBody(new
//             {
//                 name = "morpheus",
//                 job = "leader"
//             });

//             var response = await _client.ExecuteAsync(request);

//             Assert.That(response.IsSuccessful, Is.True, "Response was not successful");
//             TestContext.WriteLine(response.Content);
//         }
//     }
// }
using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;

namespace RestSharpApi
{
    public class PostTests
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
        public async Task CreateUser_ReturnsSuccess()
        {
            var request = new RestRequest("/api/users", Method.Post);

            request.AddHeader("x-api-key", "reqres-free-v1");
            request.AddHeader("Accept", "application/json");

            request.AddJsonBody(new
            {
                name = "morpheus",
                job = "leader"
            });

            var response = await _client.ExecuteAsync(request);

            Assert.That(response.IsSuccessful, Is.True, "Response was not successful");
            TestContext.WriteLine(response.Content);
        }
    }
}
