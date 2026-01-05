namespace MetrixApi.Models
{
    public class BarcodeScan
    {
        public int Id { get; set; }

        // Nullable string properties
        public string? Code { get; set; }
        public string? UserId { get; set; }

        public DateTime ScannedAt { get; set; }
    }
}