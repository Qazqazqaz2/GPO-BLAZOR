using System.Net.Http.Json;

namespace GPO_BLAZOR.Client.Class.Date
{

    /// <summary>
    /// Модель значений выпадющего списка
    /// </summary>
    public record CollectionValues
    {
        private CollectionValues(string[] value)
        {


            if (value != null)
                Values = value;
            else Values = null;
        }

        public string[] Values { get; init; }

        public static async Task<CollectionValues> Create(string Name)
        {
            return new CollectionValues(await GetAtributes(Name));
        }

        private static async Task<string[]> GetAtributes(string Field)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri($"https://{IPaddress.IPAddress}/GetAtributes/{Field}");
                return await httpClient.GetFromJsonAsync<string[]>(httpClient.BaseAddress);
            }
        }

    }
}