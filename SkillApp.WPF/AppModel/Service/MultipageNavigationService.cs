using System;

namespace SkillApp.WPF.AppModel.Service
{
    public class MultipageNavigationService : IMultipageNavigationService
    {
        private VMBase _currentViewModel;
        public VMBase CurrentViewModel
        {
            get => _currentViewModel; private set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public void Navigate(VMBase viewModel)
        {
            CurrentViewModel = viewModel;
        }
    }
}
