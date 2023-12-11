namespace ASPMind.Models.Request
{
    public class ModelRequest
    {
        public int Id { get; set; } 
        public string Name {  get; set; }
        public int IdType { get; set; }
        public int IdBrand { get; set; }
        public int? Stock { get; set; }
        public int? StockAvailable { get; set; }
    }
}
