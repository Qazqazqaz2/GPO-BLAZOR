using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace GPO_BLAZOR.Client.Class.Date
{
    class Comparer: IEqualityComparer<KeyValuePair<string, IField>>
    {
        public bool Equals(KeyValuePair<string, IField> b1, KeyValuePair<string, IField> b2)
        {
            if (ReferenceEquals(b1, b2))
                return true;

            return b1.Key == b2.Key;
        }

        public int GetHashCode(KeyValuePair<string, IField> Container) => Container.GetHashCode();

    }

    public class Statmen: DictionaryValueGetter, IStatmen
    {
        public Page[] Date { get; set; }

        private string? _id = "";

        private string Id 
        {
            get
            {
                return _id;
            }
            set
            {
                _id = (_id==null)||(_id=="")?value:_id;
            } 
        }


        public override IEnumerable<KeyValuePair<string, IField>> GetValues()
        {
            var result = base.GetValues(Date);

            IEnumerable < KeyValuePair<string, IField> > AddId (IEnumerable<KeyValuePair<string, IField>> values)
            {
                yield return new KeyValuePair<string, 
                    IField>("id", (new Field { Id = "Id", ClassType = "HiddenField", Name = "Id", Text = _id, value = Id }));
                foreach (var item in  values) 
                {
                    yield return item;
                }
                yield break;
            }

            return AddId(result);
        }

        public async static Task<IStatmen> Create(string id, IJSRuntime jsr)
        {
            Dictionary<string, string> values;
            try
            {
                    values = await Requesting.AutorizationRequest<Dictionary<string, string>>(
                        new Uri($"https://{IPaddress.IPAddress}/getformDate:{id}"),
                        jsr);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"getFormDateException -> {ex.Message}");
                values = null;
            }

            try
            {
                var addId = (Statmen statmen, string id) =>
                {
                    statmen.Id = id;
                    return statmen;
                };

                IStatmen StatmenTemplate = addId(await Requesting.AutorizationRequest<Statmen>(
                    new Uri($"https://{IPaddress.IPAddress}/getTepmlate/{values["Template"]}"),
                    jsr), id);

                var t = FillTemplate(values, StatmenTemplate);

                return t;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"getTemplateException -> {ex.Message}");
                return null;
            }


        }

        private static IStatmen FillTemplate(Dictionary<string, string> values, IStatmen voidTemplate)
        {
            var teplateDictionarytemp = voidTemplate.GetValues();
            var compar = new Comparer();

            //foreach (var iter in teplateDictionarytemp)
            //    Console.WriteLine("dictionarykey-> " + iter.Key);

            var teplateDictionarytemp2 = teplateDictionarytemp.Distinct(compar);
            //foreach (var iter in teplateDictionarytemp2)
            //    Console.WriteLine("DICTIONRKEY -> " + iter.Key);
            try
            {
                var teplateDictionary = teplateDictionarytemp2.ToDictionary();
                foreach (var item in values)
                {
                    if (teplateDictionary.ContainsKey(item.Key))
                    {
                        //Console.WriteLine($"|||| {item.Key} : {item.Value} : {teplateDictionary[item.Key].value}");
                        teplateDictionary[item.Key].value = item.Value;
                        //Console.WriteLine($"---- {item.Key} : {item.Value} : {teplateDictionary[item.Key].value}");
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ToDictionaryError -> {ex.Message}");
            }
            finally
            {

            }

            return voidTemplate;
        }

        public async Task<string> SendDate()
        {
            using HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri($"https://{IPaddress.IPAddress}/getInfo");

            Dictionary<string, string> temp = new Dictionary<string, string>();
            foreach (var item in GetValues())
            {
#if DEBUG
                Console.WriteLine($"Fill templete item: {item.Key} item: {item.Value}");
#endif
                temp.TryAdd(item.Key, item.Value.value);
            }

            var response = await httpClient.PostAsJsonAsync(httpClient.BaseAddress, temp);

            //var a = (httpClient.Send(new HttpRequestMessage())).Content.ReadAsStream();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
