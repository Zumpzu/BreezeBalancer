using System.ComponentModel.DataAnnotations;

namespace WindParkController.Model
{
    public class MarketPriceDto
    {
        // The current market price limit.
        [Required]
        public float PriceLimit { get; set; }
    }
}
