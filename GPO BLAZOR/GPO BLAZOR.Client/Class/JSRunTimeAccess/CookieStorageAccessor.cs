using Microsoft.JSInterop;

namespace GPO_BLAZOR.Client.Class.JSRunTimeAccess
{
    public class CookieStorageAccessor : JSAccessor
    {

        public CookieStorageAccessor(IJSRuntime jSRuntime)
            : base(jSRuntime, "CookieStorageAccessor")
        {

        }

        public async Task WriteCookieAsync<T>(string key, T value, DateTime Time)
        {
            try
            {
                await WaitForReference();
                await _accessorJsRef.Value.InvokeVoidAsync("WriteCookie", key, value, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("WriteCookie Error " + ex.Message);
            }
        }

        public async Task<T> ReadCookieAsync<T>(string key) where T : class
        {
            try
            {
                await WaitForReference();
                var result = await _accessorJsRef.Value.InvokeAsync<T>("ReadCookie", key);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
