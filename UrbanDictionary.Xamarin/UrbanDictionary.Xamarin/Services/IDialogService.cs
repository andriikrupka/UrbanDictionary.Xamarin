using System.Threading.Tasks;

namespace UrbanDictionary.Xamarin
{
    public interface IDialogService
    {
        Task<bool> ShowDialogAsync(string title, string message, string okButton);
        Task<bool> ShowDialogAsync(string title, string message, string okButton, string cancelButton);
    }
}
