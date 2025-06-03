namespace Stockify.Web.ViewModels;
public class SelectOption
{
    public int Value { get; set; }
    public string Text { get; set; }
    public int Max { get; set; }
    public bool Disabled { get; set; } = false;
}
