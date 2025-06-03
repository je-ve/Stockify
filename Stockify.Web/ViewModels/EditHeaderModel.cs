using System.ComponentModel.DataAnnotations;
namespace Stockify.Web.ViewModels;
public class EditHeaderModel
{
    [Required(ErrorMessage = "Selecteer een klant.")]
    public int SelectedCustomerId { get; set; }
}

