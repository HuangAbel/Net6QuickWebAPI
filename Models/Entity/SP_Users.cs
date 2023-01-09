namespace Models.Entity
{
    public class SP_Users : ShareEntity
    {
        [StoreProcedureInput]
        public string UserId { get; set; }
        [StoreProcedureInput]
        public string UserName { get; set; }
    }
}
