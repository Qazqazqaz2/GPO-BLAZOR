namespace GPO_BLAZOR.Client.Class.Date;

public interface IStatmen: IDictionaryFieldValue
{
    Page[] Date { get; set; }

    Task<string> SendDate();
}