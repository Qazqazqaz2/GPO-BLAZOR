namespace GPO_BLAZOR.Client.Class.Date
{
    public interface IPage: IDictionaryFieldValue
    {
        string PageName { get; set; }
        Block[] Date { get; set; }
    }
}