using System.ComponentModel.DataAnnotations;
using Stockify.Objects;
namespace Stockify.Web.ViewModels;
public class StockActionInputModel
{
    public int? MaxValue { get; set; }  // Maximale waarde voor de hoeveelheid, indien aanwezig


    [Required(ErrorMessage = "Type")]
    public StockActionType Type { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "De hoeveelheid moet minstens 1 zijn.")]
    [MaxValueIfPresent(ErrorMessage = "Aantal mag niet groter zijn dan de beschikbare voorraad.")]
    public int Quantity { get; set; }
}

