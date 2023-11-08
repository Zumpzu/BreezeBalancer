using System.ComponentModel.DataAnnotations;

namespace WindParkController.Model
{
    public class MarketPriceDto
    {
        [Required]
        public float PriceLimit { get; set; }
    }
}
