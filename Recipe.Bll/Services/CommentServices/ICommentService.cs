using Recipe.Dtos.Request;
using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.CommentServices
{
    public interface ICommentService
    {
        void CreateComment(CreateCommentRequestDto request);
        void UpdateComment(UpdateCommentRequestDto request);
        void DeleteComment(DeleteCommentRequestDto request);
        CommentResponseDto GetCommentById(GetCommentByIdRequestDto request);
        List<CommentResponseDto> GetAllComment();
    }
}
