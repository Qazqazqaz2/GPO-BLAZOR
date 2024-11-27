using GPO_BLAZOR.Client.Class.Date;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GPO_BLAZOR.Client.Parts
{
    public partial class NewPostForm
    {
        INewPost postModel;

        public void Click()
        {
            action = postModel.Fields[actionWord];
            action();
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                postModel = await NewPost.Create(Navigator, jsr);
                action = postModel.Fields.First().Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"New Post Exception -> {ex.Message}");
            }

        }
        [Parameter]
        public NavigationManager Navigator { get; set;}
        string actionWord { get; set; } 
        Func<Task> action { get; set; } = () => null;
        
    }
}
