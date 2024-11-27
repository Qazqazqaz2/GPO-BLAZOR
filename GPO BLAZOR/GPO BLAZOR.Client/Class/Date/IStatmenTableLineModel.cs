namespace GPO_BLAZOR.Client.Class.Date
{
    public interface IStatmenTableLineModel
    {
        string id { get; init; }
        DateTime Time { get; init; }
        State State { get; init; }
        PracticType PracticType { get; init; }

        int Number { get; set; }
    }
}
