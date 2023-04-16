using System;
using System.ComponentModel;
using SkillApp.WPF.AppModel;

namespace NightWorld.AppModel.Stores
{
    public sealed class NavigationStore
    {
        private VMBase _currentViewModel;
        public VMBase CurrentViewModel
        {
            get => _currentViewModel; set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged() 
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
