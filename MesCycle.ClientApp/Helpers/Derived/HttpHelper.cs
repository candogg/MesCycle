using MesCycle.ClientApp.Extensions;
using MesCycle.ClientApp.Helpers.Base;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MesCycle.ClientApp.Helpers.Derived
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public sealed class HttpHelper : HelperBase<HttpHelper>
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public HttpHelper()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public async Task<TResponse> PostAsync<TResponse, TRequest>(TRequest requestItem, string url, CancellationToken continuationToken)
        {
            var resultItem = Activator.CreateInstance<TResponse>();

            if (requestItem == null) return resultItem;

            var body = requestItem.Serialize();

            if (body.IsNullOrEmpty()) return resultItem;

            try
            {
                var buffer = Encoding.UTF8.GetBytes(body);

                using (var byteContent = new ByteArrayContent(buffer))
                {
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    using (var result = await httpClient.PostAsync(url, byteContent, continuationToken).ConfigureAwait(false))
                    {
                        var postResult = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

                        if (postResult.IsNullOrEmpty()) return default;

                        resultItem = postResult.Deserialize<TResponse>();

                        return resultItem;
                    }
                }
            }
            catch (TaskCanceledException) { }
            catch (Exception)
            { }

            return default;
        }
    }
}
