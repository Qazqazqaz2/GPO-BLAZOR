using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace GPO_BLAZOR.Client.Class.Date
{
    public class StatmenTableModel: IStatmenTableModel
    {
        private IJSRuntime jsr { init; get; }
        private IStatmenTableLineModel[] _lines;

        public IStatmenTableLineModel[] Lines
        {
            get
            {
                ref IStatmenTableLineModel[] result = ref _lines;
                return result;
            }
            set
            {
                _lines = value;
            }
        }

        private StatmenTableModel(IStatmenTableLineModel[] components, IJSRuntime jsr)
        {
            this.jsr = jsr;
            Lines = components;
        }

        static async public Task<StatmenTableModel> Create(IJSRuntime jsr, string? token = null)
        {
            return new StatmenTableModel(await GetLines(token, jsr), jsr);
        }

        private StatmenTableModel(string token)
        {
            var response = GetLines(token, jsr);

            while (!response.IsCompleted)
            {
                
            }
            Lines = response.Result;

        }

        private static async Task<IStatmenTableLineModel[]> GetLines(string? token, IJSRuntime jsr)
        {
            var response = await Requesting.AutorizationRequest<StatmenTableLineModel[]>(
                new Uri($"https://{IPaddress.IPAddress}/getstatmens/user:{(token != null ? "token" : "-")}"),
                jsr);

            int calculator = 0;
            foreach (var item in response)
            {
                item.Number = calculator++;
            }

            return response;
        }

        public void Add(IStatmenTableLineModel addingItem)
        {
            Array.Resize(ref _lines, Lines.Length+1);
            _lines[_lines.Length-1] = addingItem;
        }
    }
}
