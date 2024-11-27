using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace GPO_BLAZOR.Client.Class.Date
{
    public interface INewPost
    {
        IJSRuntime JSRuntime { get; init; }
        IDictionary<string, Func<Task>> Fields { get; }
        NavigationManager Navigator { get; init; }
    }

    public class NewPost : INewPost
    {
        public static async Task<INewPost> Create (NavigationManager Navigator, IJSRuntime jsr)
        {
            NewPost newpost = new NewPost(Navigator, jsr);
            try
            {
                try
                {
                    var values = (async () => (await Requesting.AutorizationRequest<string[]>(
                            new Uri($"https://{IPaddress.IPAddress}/GetAtributes/Postlist"),
                            newpost.JSRuntime)));
                    newpost._fields = await values();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"NewPost Http Constructor Exception -> {ex.Message}");
                }
                Func<string, Func<Task>> nav = null;
                try
                {
                    nav = (string str) => async () => Navigator.NavigateTo($"/statmen/New/{str}", true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"NewPost FuncConstructor Exception -> {ex.Message}");
                }

                newpost.Fields = newpost._fields.Select(x => new KeyValuePair<string, Func<Task>>(x, nav(x))).ToDictionary();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"NewPost Constructor Exception -> {ex.Message}");
            }
            return newpost;
        }
        private NewPost(NavigationManager Navigator, IJSRuntime jsr)
        {
            this.Navigator = Navigator;
            JSRuntime = jsr;
        }
        public IJSRuntime JSRuntime { get; init; }
        public NavigationManager Navigator { get; init; }
        private string[] _fields;
        public IDictionary<string, Func<Task>> Fields { get; set; }
    }
}


