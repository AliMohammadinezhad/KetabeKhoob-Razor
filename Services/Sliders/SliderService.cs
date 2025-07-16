using KetabeKhoob.Razor.Infrastructure.Utils.CustomValidation.IFormFile;
using KetabeKhoob.Razor.Models;
using KetabeKhoob.Razor.Models.Sliders;

namespace KetabeKhoob.Razor.Services.Sliders;

public class SliderService : ISliderService
{
    private readonly HttpClient _httpClient;

    private const string ModuleName = "Slider";

    public SliderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResult> CreateSlider(CreateSliderCommand command)
    {
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(command.Link), "Link");
        formData.Add(new StringContent(command.Title), "Title");
        formData.Add(new StringContent(command.Position.ToString()), "Position");
        formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
        var result = await _httpClient.PostAsync(ModuleName, formData);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> EditSlider(EditSliderCommand command)
    {
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(command.Link), "Link");
        formData.Add(new StringContent(command.Title), "Title");
        formData.Add(new StringContent(command.Position.ToString()), "Position");
        formData.Add(new StringContent(command.Id.ToString()), "Id");

        if (command.ImageFile.IsImage() && command.ImageFile.Length > 0 && command.ImageFile != null)
            formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
        
        var result = await _httpClient.PutAsync(ModuleName, formData);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> DeleteSlider(long sliderId)
    {
        var result = await _httpClient.DeleteAsync($"{ModuleName}/{sliderId}");
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<SliderDto?> GetSliderById(long sliderId)
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<SliderDto?>>($"{ModuleName}/{sliderId}");
        return result?.Data;
    }

    public async Task<List<SliderDto?>> GetSliders()
    {
        var result = await _httpClient.GetFromJsonAsync<ApiResult<List<SliderDto?>>>(ModuleName);
        return result?.Data;
    }
}