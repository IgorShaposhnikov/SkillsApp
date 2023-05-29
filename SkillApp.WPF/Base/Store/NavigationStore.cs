using System;

namespace SkillApp.WPF.Base.Store
{
    public class NavigationStore : VMBase, INavigationStore
    {
        private VMBase _currentViewModel;
        public VMBase CurrentViewModel
        {
            get => _currentViewModel; set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }


        public event CurrentViewModelChangedEventHandler CurrentViewModelChanged;
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
