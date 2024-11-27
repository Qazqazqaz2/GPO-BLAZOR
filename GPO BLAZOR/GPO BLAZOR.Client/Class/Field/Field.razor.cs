using GPO_BLAZOR.Client.Class.Date;
using Microsoft.AspNetCore.Components;

namespace GPO_BLAZOR.Client.Class.Field
{
    public partial class Field
    {
        [Parameter]
        public IField Date { get; set; }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return base.OnAfterRenderAsync(firstRender);
        }
    }
}
