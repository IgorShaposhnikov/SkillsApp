using System;
using SkillApp.WPF.AppModel;

namespace NightWorld.AppModel.Stores
{
    public class ModalNagivationStore
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

        public bool IsOpen => CurrentViewModel != null;
        public void Close() => CurrentViewModel = null;


        public Action CurrentViewModelChanged;
        private void OnCurrentViewModelChanged() 
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
