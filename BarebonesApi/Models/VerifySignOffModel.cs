using System.ComponentModel.DataAnnotations;

namespace UnhingedApi.Models;

public class VerifySignOffModel
{
    [Required]
    [MinLength(3)]
    [MaxLength(500)]
    public string SignOff { get; set; }
    [Required]
    [MaxLength(100)]
    public string Author { get; set; }
}
