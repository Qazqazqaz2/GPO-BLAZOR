using GPO_BLAZOR.Client.Class.Date;
using Microsoft.AspNetCore.Components;

namespace GPO_BLAZOR.Client.Class.Field
{
    public partial class SelectedTextField: Field
    {

        private bool IsLoading;

        private CollectionValues collection;

        protected override async Task OnInitializedAsync()
        {
            IsLoading = false;
            try
            {
                collection = (Date is not null)?await CollectionValues.Create(Date.Id):collection;
            }
            finally
            {
                await base.OnInitializedAsync();
            }
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                
                collection = await CollectionValues.Create(Date.Id);
                

            }
            catch (Exception ex)
            {
                Console.WriteLine($"SelectedTextFieldException -> {ex.Message}");
            }
            finally
            {
                await base.OnParametersSetAsync();
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            IsLoading = true;
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
