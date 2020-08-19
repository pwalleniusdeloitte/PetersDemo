using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string navn = "demo";
            Console.WriteLine($"Sender: {navn}");
            string svar = await MakeRequest(navn);
            Console.WriteLine($"Svar: {svar}");
            Console.ReadLine();
        }

        static async Task<string> MakeRequest(string navn)
        {
            string body = "{\"name\":\"" + navn + "\"}";
            var client = new HttpClient();
            var uri = "https://petersdemo.azure-api.net/PetersDemo/Capital";
            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes(body);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //Ved anvendelse af subscription key
                content.Headers.Add("Ocp-Apim-Subscription-Key", "eeaf27ede20a4be7bb2104014d68e79d");
                response = await client.PostAsync(uri, content);
            }

            return response.Content.ReadAsStringAsync().Result;

        }
    }
}
