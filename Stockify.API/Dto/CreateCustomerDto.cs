using System.ComponentModel.DataAnnotations;
using Stockify.Objects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stockify.API.Dto;
public class CreateCustomerDto
{


    /*
    [NotMapped]
    public string Number
    {
        get { return $"K{this.Id:D4}"; }
    }
    */

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
}
