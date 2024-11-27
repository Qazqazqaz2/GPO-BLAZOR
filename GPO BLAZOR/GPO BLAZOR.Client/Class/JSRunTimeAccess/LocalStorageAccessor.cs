

using Microsoft.JSInterop;

namespace GPO_BLAZOR.Client.Class.JSRunTimeAccess
{
    public class LocalStorageAccessor : JSAccessor
    {


       public LocalStorageAccessor (IJSRuntime jSRuntime)
            :base (jSRuntime, "LocalStorageAccessor")
        {
            
        }

        public async Task<T> GetValueAsync<T> (string key)
        {
            await WaitForReference();
            var result = await _accessorJsRef.Value.InvokeAsync<T>("get", key);

            return result;
        }

        public async Task SetValueAsync<T> (string key, T value)
        {
            await WaitForReference();
            await _accessorJsRef.Value.InvokeVoidAsync("set", key, value);
        }

        public async Task Clear()
        {
            await WaitForReference();
            await _accessorJsRef.Value.InvokeVoidAsync("clear");
        }

        public async Task RemoveAsync(string key)
        {
            await WaitForReference();
            await _accessorJsRef.Value.InvokeVoidAsync("remove", key);
        }

    }
}
