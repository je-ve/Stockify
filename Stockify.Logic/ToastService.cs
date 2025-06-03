namespace Stockify.Logic;
public class ToastService : IToastService
{
    public event Action<ToastMessage>? OnShow;

    public void ShowSuccess(string message)
    {
        OnShow?.Invoke(new ToastMessage { Message = message, IsError = false });
    }

    public void ShowError(string message)
    {
        OnShow?.Invoke(new ToastMessage { Message = message, IsError = true });
    }
}

public class ToastMessage
{
    public string Message { get; set; } = "";
    public bool IsError { get; set; }
}
