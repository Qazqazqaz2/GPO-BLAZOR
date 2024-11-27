using GPO_BLAZOR.Client.Class.Date;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using GPO_BLAZOR.Client.Class.JSRunTimeAccess;
using System.ComponentModel.DataAnnotations;

namespace GPO_BLAZOR.Client.Pages
{
    public partial class AutorizationForm
    {
        //[Parameter]
        //public CookieStorageAccessor cookieStorage {  get; set; }

        [Parameter]
        [Required]
        public required IAuthorizationDate AuthorizationInterface { get; set; }

        [Parameter]
        public EventCallback<IAuthorizationDate> AuthorizationInterfaceChanged { get; set; }

        private string message = null;

        private bool _isLoading = true;
        private bool isLoading {
            get
            {
                return _isLoading;
            }
            set 
            {
                _isLoading = value;
            }
        }

        [Parameter]
        public System.Timers.Timer timer { get; set; }

        private bool firstRender;

        async Task ButtonClicked()
        {

#if DEBUG            
            Console.WriteLine("Callback0: "+ AuthorizationInterface.IsCookies+ " "+ AuthorizationInterface.GetHashCode());
#endif
            try
            {
                Console.WriteLine(AuthorizationInterface);
                await AuthorizationInterface.GetValues(ReadCookies, timer);
                await AuthorizationInterfaceChanged.InvokeAsync(AuthorizationInterface);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //await Checer();
                message = "Неверное имя пользователя или пароль";
            }

        }

        string value = "value";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
#if DEBUG
            Console.WriteLine("Рендер " + firstRender);
            Console.WriteLine("Loading 1  " + isLoading);
#endif
            this.firstRender = !firstRender;
            isLoading = false;
            try
            {
                if (AuthorizationInterface._writer == null)
                    if (firstRender)
                    {
                        AuthorizationInterface = new AuthorizationDate(ReadCookies, WriteCookies);
                        await AuthorizationInterface.GetValues(ReadCookies, timer);
                        await AuthorizationInterfaceChanged.InvokeAsync(AuthorizationInterface);
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await Checer();
            }
            finally
            {
#if DEBUG
                Console.WriteLine("Loading 2  " + isLoading);
#endif
                if (firstRender)
                {
                    this.StateHasChanged();
                }
            }
        }




        protected override async Task OnInitializedAsync()
        {
#if DEBUG
            //            Console.WriteLine("Загрузились");
#endif
            isLoading = true;

        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (AuthorizationInterface._writer==null)
            AuthorizationInterface = new AuthorizationDate(ReadCookies, WriteCookies);
        }


        protected async Task Checer()
        {
            await AuthorizationInterface.GetValues(ReadCookies, timer);
            await AuthorizationInterfaceChanged.InvokeAsync();
        }




        protected async Task WriteCookies(string key, string value)
        {
#if DEBUG
            Console.WriteLine(DateTime.Now.AddMinutes(1));
#endif
                await cookieStorage.WriteCookieAsync(key, value, DateTime.Now.AddMinutes(1));
        }


        protected async Task<string> ReadCookies(string key)
        {
                string temp = await cookieStorage.ReadCookieAsync<string>(key) ?? "";
                try
                {
                    if (temp != "")
                    {
                        await AuthorizationInterfaceChanged.InvokeAsync(AuthorizationInterface);
                    }
                    return temp ?? "";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ("ReadCookies Error");
                }
        }

    }
}
