using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Banners;

namespace KetabeKhoob.Razor.Services.Banners;

public class BannerService : IBannerService
{
    private readonly HttpClient _httpClient;

    public BannerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResult> CreateBanner(CreateBannerCommand command)
    {
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(command.Link), "Link");
        formData.Add(new StringContent(command.Position.ToString()), "Position");
        formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
        var result = await _httpClient.PostAsync("banner", formData);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> EditBanner(EditBannerCommand command)
    {
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(command.Id.ToString()), "Id");
        formData.Add(new StringContent(command.Link), "Link");
        formData.Add(new StringContent(command.Position.ToString()), "Position");
        if(command.ImageFile != null && command.ImageFile.Length > 0)
            formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
        var result = await _httpClient.PutAsync("banner", formData);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> DeleteBanner(long bannerId)
    {
        var result = await _httpClient.DeleteAsync($"banner/{bannerId}");
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<BannerDto?> GetBannerById(long bannerId)
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<BannerDto>>($"banner/{bannerId}");
        return result?.Data;
    }

    public async Task<List<BannerDto>> GetBannerList()
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<List<BannerDto>>>("banner");
        if (result?.Data is null)
            return [];
        return result.Data;
    }
}