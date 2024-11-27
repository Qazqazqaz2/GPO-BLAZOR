using Microsoft.JSInterop;

namespace GPO_BLAZOR.Client.Class.JSRunTimeAccess
{
    public abstract class JSAccessor : IAsyncDisposable
    {

        protected Lazy<IJSObjectReference> _accessorJsRef = new Lazy<IJSObjectReference>();

        protected IJSRuntime _jsRuntime;

        protected string _nameModule;

        public JSAccessor(IJSRuntime jSRuntime, string nameModule)
        {
            _jsRuntime = jSRuntime;
            _nameModule = nameModule;
        }

        public async ValueTask DisposeAsync()
        {
            try
            {
                if (_accessorJsRef.IsValueCreated)
                {
                    await _accessorJsRef.Value.DisposeAsync();
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected async Task WaitForReference()
        {
            try
            {
                if (_accessorJsRef.IsValueCreated is false)
                {
                    _accessorJsRef = new(await _jsRuntime.InvokeAsync<IJSObjectReference>("import", $"/js/{_nameModule}.js"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("WaitForReference Error " + ex.Message);
            }
        }

    }
}
