using static Shared.Models.ApiModels;

namespace AppLogic.Services.ResponseServices
{
    public interface IResponseService
    {
        public HttpClient Client { get; set; }

        public Task<List<ResponseAPIModel>> GetResponses();

        public Task PostResponse(ResponseAPIModel response);
    }
}
