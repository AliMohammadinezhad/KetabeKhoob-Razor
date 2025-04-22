using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Comments;

namespace KetabeKhoob.Razor.Services.Comments;

public interface ICommentService
{
    Task<ApiResult> AddComment(AddCommentCommand command);
    Task<ApiResult> EditComment(EditCommentCommand command);
    Task<ApiResult> ChangeStatusComment(long commentId, CommentStatus status);
    Task<CommentFilterResult> GetCommentByFilter(CommentFilterParams filterParams);
    Task<CommentDto?> GetCommentById(long commentId);
}