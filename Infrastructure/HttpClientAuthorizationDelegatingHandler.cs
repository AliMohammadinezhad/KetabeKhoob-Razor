using System.Net;

namespace KetabeKhoob.Razor.Infrastructure;

public class HttpClientAuthorizationDelegatingHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _contextAccessor;

    public HttpClientAuthorizationDelegatingHandler(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (_contextAccessor.HttpContext is not null)
        {
            var token = _contextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrWhiteSpace(token) is false)
                request.Headers.Add("Authorization", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}