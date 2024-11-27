using System.Net.Http.Json;

namespace GPO_BLAZOR.Client.Class.Date
{
    public class UGRNUParser
    {

        /*record TableLine
        {
            /// <summary>
            /// Название компании
            /// </summary>
            public string c { get; init; }
            /// <summary>
            /// Руководитель
            /// </summary>
            public string g { get; init; }
            public string cnt { get; init; }
            public string i { get; init; }
            public string k { get; init; }
            public string n { get; init; }
            public string o { get; init; }
            public string p { get; init; }
            public string r { get; init; }
            public string t { get; init; }
            public string pg { get; init; }
            public string tot { get; init; }
            public string rn { get; init; }


        }

        record FirstQuestion
        {
            public string t { get; init; }
            public bool captchaRequired { get; init; }
        }

        private async Task<FirstQuestion> getFirstQuestion()
        {
            using HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://egrul.nalog.ru");
            var response = await httpClient.PostAsJsonAsync( httpClient.BaseAddress, "vyp3CaptchaToken=&page=&query=%D0%A2%D1%83%D1%81%D1%83%D1%80&region=&PreventChromeAutocomplete=");

            Task<FirstQuestion> result = response.Content.ReadFromJsonAsync<FirstQuestion>();
            return await result;

        }*/


    }
}
