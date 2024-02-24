using Newtonsoft.Json;
using System.Net.Http.Json;
using static Shared.Models.ApiModels;

namespace AppLogic.Services.ResponseServices
{
    public class ResponseService : IResponseService
    {
        // Klass som gör anrop till API:et för att hämta data, deseralisera den och omvandla till en APImodell.  
        public HttpClient Client { get; set; } = new()
        {
            BaseAddress = new Uri("https://localhost:7249/")
        };


        public async Task<List<ResponseAPIModel>> GetResponses()
        {
            var response = await Client.GetAsync("Responses");

            if (response.IsSuccessStatusCode)
            {
                string responseInjson = await response.Content.ReadAsStringAsync();

                List<ResponseAPIModel>? responses = JsonConvert.DeserializeObject<List<ResponseAPIModel>>(responseInjson);

                if (responses != null)
                {
                    return responses;
                }

                throw new JsonException();
            }

            throw new HttpRequestException();
        }

        public async Task PostResponse(ResponseAPIModel response)
        {
            await Client.PostAsJsonAsync("responses", response);
        }
    }
}
