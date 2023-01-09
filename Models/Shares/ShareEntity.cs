namespace Models
{
    public enum DataState
    {
        Update = 1,
        Insert = 2
    }
    public class ShareEntity
    {
        [StoreProcedureInput]
        public string? ExecuteType { get; set; }
        public DataState? dataState { get; set; }
    }
}
