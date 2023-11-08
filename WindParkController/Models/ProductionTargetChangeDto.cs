using System.ComponentModel.DataAnnotations;

namespace WindParkController.Model;

public class ProductionTargetChangeDto
{
    // Positive value to increase, negative value to decrease the production target.
    [Required]
    public float AdjustmentValue { get; set; }
}