namespace GPO_BLAZOR.Client.Class.Date
{
    public abstract class DictionaryValueGetter : IDictionaryFieldValue
    {
        protected IEnumerable<KeyValuePair<string, IField>> GetValues(IDictionaryFieldValue[] Date)
        {
            Stack<KeyValuePair<string, IField>> result = new Stack<KeyValuePair<string, IField>>();
            foreach (var field in Date)
                foreach (var item in field.GetValues())
                {
                    result.Push(item);
                };
            return result;
        }

        public abstract IEnumerable<KeyValuePair<string, IField>> GetValues();
    }
}
