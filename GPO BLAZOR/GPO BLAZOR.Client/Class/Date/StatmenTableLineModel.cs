namespace GPO_BLAZOR.Client.Class.Date
{
    /// <summary>
    /// Модель строки таблицы
    /// </summary>
    public record StatmenTableLineModel: IStatmenTableLineModel
    {
        public string id { get; init; }
        public DateTime Time { get; init; }
        public State State { get; init; }
        public PracticType PracticType { get; init; }

        public int Number { get; set; }

    }
}
