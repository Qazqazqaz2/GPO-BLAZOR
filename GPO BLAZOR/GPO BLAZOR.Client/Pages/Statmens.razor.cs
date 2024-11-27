using GPO_BLAZOR.Client.Class.Date;
using GPO_BLAZOR.Client.Parts;
using Microsoft.AspNetCore.Components;
using Navigation = Microsoft.AspNetCore.Components.NavigationManager;


namespace GPO_BLAZOR.Client.Pages
{
    public partial class Statmens
    {
        //private Statmens c { get; set; } = new Statmens();

        //

        [Parameter]
        public EventCallback<(string, int)> ViemStatmen { get; set; }

        public IStatmenTableModel? Date { get; set; }

        private bool NewPostMenuViem = false;

        protected override async Task OnInitializedAsync()
        {
            
            isLoadind = false;

            try
            {
                Date ??= await StatmenTableModel.Create(jsr);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"StatmensTableCreatorException -> {ex.Message}");
            }
        }

        protected override async Task OnParametersSetAsync()
        {
            isLoadind = true;
        }

        private bool isLoadind { get; set; } = false;


        async Task Click((string id, int num) item)
        {
            var command = (async (string id, int num) => {
                string way = $"statmen/{num}";
                Navigation.NavigateTo(way);
            });

            command(item.id, item.num);

            await ViemStatmen.InvokeAsync(item);
        }


        async Task NewPost()
        {
            NewPostMenuViem = true;
            

            
        }

        private async Task PostWrotten ()
        {
            NewPostMenuViem = false;
        }
    }
}
