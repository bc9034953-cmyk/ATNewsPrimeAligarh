using ATNewsprimeApp.DtoRequest;
using ATNewsprimeApp.DtoResponse;

namespace ATNewsprimeApp.IService
{
    public interface ICommentService
    {
        Task<CommentResponse> AddCommentAsync(AddCommentRequest request);
        Task<List<CommentResponse>> GetAllCommentsAsync(int? NewsId = null);
        Task<DeleteCommentResponse> DeleteCommentByIdAsync(int CommentId);
    }
}
