namespace Domain.Models
{
    public sealed class Maintenance
    {
        public int Id { get; set; }
        public string? Item { get; set; }
        public string? Operation { get; set; }
        public int Every { get; set; }
    }
}
