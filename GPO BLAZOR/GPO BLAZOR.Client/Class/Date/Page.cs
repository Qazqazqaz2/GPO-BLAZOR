namespace GPO_BLAZOR.Client.Class.Date
{

    public class Page: DictionaryValueGetter, IPage
    {
        public string PageName { get; set; }
        public Block[] Date { get; set; }

        public override IEnumerable<KeyValuePair<string, IField>> GetValues()
        {
            return base.GetValues(Date);
        }
    }
}