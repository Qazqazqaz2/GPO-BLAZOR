namespace GPO_BLAZOR.Client.Class.Date
{
    public interface IField : IDictionaryFieldValue
    {
        string Id { get; init; }
        string Name { get; init; }
        string Text { get; init; }
        string ClassType { get; init; }

        string value { get; set; }

        bool IsDisabled { get; init; }
    }
}
