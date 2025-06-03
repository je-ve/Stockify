namespace Stockify.Logic;
public interface IToastService
{
    event Action<ToastMessage>? OnShow;
    void ShowSuccess(string message);
    void ShowError(string message);
}
