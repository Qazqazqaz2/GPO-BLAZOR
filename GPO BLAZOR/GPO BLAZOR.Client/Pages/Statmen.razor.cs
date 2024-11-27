using System.Data;
using GPO_BLAZOR.Client.Class.Date;
using Microsoft.AspNetCore.Components;


namespace GPO_BLAZOR.Client.Pages
{
    public partial class Statmen
    {
        [Parameter]
        public IStatmen? Date { get; set; }

        [Parameter]
        public int Number { get; set; }

        [Parameter]
        public EventCallback Return { get; set; }

        private bool isLoading;

        private IPage SelectedPage;

        protected async Task ChangeValue(IPage selectPage)
        {
            SelectedPage = selectPage;

        }
        private async Task SetDate()
        {

            try
            {
                Console.WriteLine($"SendDateMessage -> {await Date.SendDate()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SendDateViemException -> {ex.Message}");
            }
            finally
            {
                Navigation.NavigateTo("/");
                if (Return.HasDelegate)
                    await Return.InvokeAsync();
            }

        }

        protected override async Task OnInitializedAsync()
        {
            isLoading = false;
            try
            {
                 string id = (await StatmenTableModel.Create(jsr)).Lines[Number].id;
                 Date = await Class.Date.Statmen.Create(id, jsr);
                 SelectedPage = Date.Date.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"StatmenRenderingException -> {ex.Message}");
            }
        }

        protected override void OnParametersSet()
        {
            isLoading = true;
        }
    }
}
