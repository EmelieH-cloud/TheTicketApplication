using static Shared.Models.ApiModels;

namespace AppLogic.Services.TagService
{
    public interface ITagService
    {
        public HttpClient Client { get; set; }

        public Task<List<TagModelAPIModel>> GetTags();

        public Task<TagModelAPIModel> GetTagbyId(int id);

        public Task PostTag(TagModelAPIModel tag);
    }
}
