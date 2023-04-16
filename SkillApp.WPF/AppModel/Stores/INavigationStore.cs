using System.ComponentModel;

namespace NightWorld.AppModel.Stores
{
    interface INavigationStore<ViewModel> where ViewModel : class, INotifyPropertyChanged
    {
        ViewModel CurrentViewModel { get; set; }
    }
}
