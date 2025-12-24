using ATNewsprimeApp.DtoRequest;
using ATNewsprimeApp.DtoResponse;
using ATNewsprimeApp.Entitys;

namespace ATNewsprimeApp.IService
{
    public interface INewsService
    {
        Task<NewsResponse> AddNewsAsync(NewsCreateRequest request);
        Task<List<News>>GetAllNewAsyncs();
        Task<News> GetNewsByIdAsync(int id);
        Task<NewsResponse> UpdatNewsByIdAsync(int id,UpdatedNewsRequest request);
        Task<DeleteNewsReaponse> DeleteNewsByIdAsync(int id);
        Task<List<News>> GetAllPublicedNewAsyncs();
    }
}
