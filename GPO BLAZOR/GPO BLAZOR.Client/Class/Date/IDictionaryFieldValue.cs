namespace GPO_BLAZOR.Client.Class.Date;

public interface IDictionaryFieldValue
{
    public IEnumerable<KeyValuePair<string, IField>> GetValues();
}