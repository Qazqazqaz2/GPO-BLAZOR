namespace GPO_BLAZOR.Client.Class.Date
{
    public interface IStatmenTableModel
    {
        IStatmenTableLineModel[] Lines { get; set; }

        public void Add (IStatmenTableLineModel  addingLine);
    }
}
