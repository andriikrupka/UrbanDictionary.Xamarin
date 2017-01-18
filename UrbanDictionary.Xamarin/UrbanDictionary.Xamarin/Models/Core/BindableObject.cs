using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace UrbanDictionary.Models.Core
{
    public class BindableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            var handler = Volatile.Read(ref PropertyChanged);
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
