using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class HttpClientLogger : DelegatingHandler
{
    public HttpClientLogger(HttpMessageHandler innerHandler)
        : base(innerHandler)
    {
    }
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        Console.WriteLine($"HTTP İstek Gönderildi: {request.Method} {request.RequestUri}");
        HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
        Console.WriteLine($"HTTP Yanıt Alındı: {response.StatusCode}");
        return response;
    }
}
