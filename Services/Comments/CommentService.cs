using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Categories;
using KetabeKhoob.Razor.Models.Comments;

namespace KetabeKhoob.Razor.Services.Comments;

public class CommentService : ICommentService
{
    private readonly HttpClient _httpClient;

    public CommentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResult> AddComment(AddCommentCommand command)
    {
        var result = await _httpClient.PostAsJsonAsync("Comment", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> EditComment(EditCommentCommand command)
    {
        var result = await _httpClient.PutAsJsonAsync("Comment", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> ChangeStatusComment(long commentId, CommentStatus status)
    {
        var result = await _httpClient.PostAsJsonAsync("Comment/ChangeStatus"
            , new
        {
            id = commentId, status
        });
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<CommentFilterResult> GetCommentByFilter(CommentFilterParams filterParams)
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<CommentFilterResult>>("Comment");
        return result?.Data;
    }

    public async Task<CommentDto?> GetCommentById(long commentId)
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<CommentDto?>>($"Comment/{commentId}");
        return result?.Data;
    }
}