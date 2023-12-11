namespace ASPMind.Models.Request
{
    public class InventoryRequest
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public int IdModel { get; set; }
        public int IdType { get; set; }
        public bool Available { get; set; }
        public string? Description { get; set; }
    }
}
