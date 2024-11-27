using GPO_BLAZOR.Client.Class.JSRunTimeAccess;
using Microsoft.JSInterop;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace GPO_BLAZOR.Client.Class.Date
{
    public static class Requesting
    {
        static Requesting ()
        {
            Action A = () =>
            {
                Console.WriteLine("ErrorAutorization");
            };
            _errorAutorization = A; ;
        }
        static private Action? _errorAutorization;
        static public event Action ErrorAutorization
        {
            add => _errorAutorization+=value;
            remove => _errorAutorization -= value;
        }

        public async static Task<T> AutorizationRequest<T> (Uri uri, IJSRuntime jsr)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var cookieStorage = new CookieStorageAccessor(jsr);
                httpClient.BaseAddress = uri;
                var jwt = await cookieStorage.ReadCookieAsync<string>("Autorization");
                //Console.WriteLine ("Path2: "+ IPaddress.helper + " " + IPaddress.IPAddress);
                using var requestMessage = new HttpRequestMessage(HttpMethod.Get, httpClient.BaseAddress);
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                var tempresponce = await httpClient.SendAsync(requestMessage);
                if (tempresponce.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _errorAutorization();
                }
                return await tempresponce.Content.ReadFromJsonAsync<T>();
            }
        }

        public async static Task<T> AutorizationRequest<T, C>(Uri uri, IJSRuntime jsr, C Date)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var cookieStorage = new CookieStorageAccessor(jsr);
                httpClient.BaseAddress = uri;
                var jwt = await cookieStorage.ReadCookieAsync<string>("Autorization");
                //Console.WriteLine("Path2: " + IPaddress.helper+" "+IPaddress.IPAddress);
                using var requestMessage = new HttpRequestMessage(HttpMethod.Post, httpClient.BaseAddress);
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                requestMessage.Content = JsonContent.Create(Date);

                var tempresponce = await httpClient.SendAsync(requestMessage);
                if (tempresponce.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _errorAutorization();
                }
                return await tempresponce.Content.ReadFromJsonAsync<T>();
            }
        }
    }
}

