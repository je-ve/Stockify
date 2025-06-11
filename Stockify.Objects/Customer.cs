using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stockify.Objects;
public class Customer
{
    [Key]
    public int Id { get; set; }

    [NotMapped]
    public string Number
    {
        get { return $"K{this.Id:D4}"; }
    }

    [Required]
    [EmailAddress(ErrorMessage = "Ongeldig e-mailadres")]
    [StringLength(100, ErrorMessage = "Het e-mailadres is te lang")]
    public string Email { get; set; } = "test@test.test";

    [Required]
    [StringLength(50, ErrorMessage = "De naam is te lang")]
    public string Name { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "De straatnaam is te lang")]
    public string Street { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "De naam plaatsnaam is te lang")]
    public string City { get; set; }

    [Required]
    [RegularExpression(@"^\d{4}$", ErrorMessage = "De postcode heeft niet juiste vorm.")]
    public string ZipCode { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string? CreatedById { get; set; }

    [ForeignKey(nameof(CreatedById))]
    public ApplicationUser? CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public string? UpdatedById { get; set; }
    
    [ForeignKey(nameof(UpdatedById))]
    public ApplicationUser? UpdatedBy { get; set; }

    [NotMapped]
    public string Address { get { return $"{Street}, {ZipCode} {City}"; } }
}

