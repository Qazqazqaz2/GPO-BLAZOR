namespace GPO_BLAZOR.Client.Class.Date
{
    public class Block : DictionaryValueGetter, IBlock
    {
        public string BlockName { get; set; }
        public Field[] Date { get; set; }

        public override IEnumerable<KeyValuePair<string, IField>> GetValues()
        {
            return base.GetValues(Date);
        }
    }
}
