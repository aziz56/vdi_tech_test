using System.ComponentModel.DataAnnotations;

namespace Technical_TestVDI.Models
{
    public class DiscountEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TransaksiId { get; set; }
        [Required]
        public string CustomerType { get; set; }
        public int PointReward { get; set; }
        public double TotalBelanja { get; set; }
        public double Diskon { get; set; }
        public double TotalBayar { get; set; }
    }
}
