namespace GPO_BLAZOR.Client.Class.Date
{
    public interface IBlock : IDictionaryFieldValue
    {
        string BlockName { get; set; }
        Field[] Date { get; set; }
    }
}