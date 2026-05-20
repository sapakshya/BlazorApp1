using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Client
{
    public class InventoryItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int Quantity { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
