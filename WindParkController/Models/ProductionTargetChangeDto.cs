using System.ComponentModel.DataAnnotations;

namespace WindParkController.Model;

public class ProductionTargetChangeDto
{
    [Required]
    public float AdjustmentValue { get; set; }
}