using SkillApp.WPF.Base.Modal;

namespace SkillApp.WPF.Base.Store
{
    public sealed class ModalNavigationStore : VMBase, IModalNavigationStore
    {
        #region Singleton
        
        
        public static ModalNavigationStore Instance { get; } = new ModalNavigationStore();

        private ModalNavigationStore() { }
        
        
        #endregion Singleton


        private IModalViewModel _currentViewModel;
        public IModalViewModel CurrentViewModel
        {
            get => _currentViewModel; private set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        private bool _isOpen;
        public bool IsOpen 
        {
            get => _isOpen; private set 
            {
                _isOpen = value;
                OnPropertyChanged();
            }
        }

        public void Open(IModalViewModel viewModel) 
        {
            IsOpen = true;
            CurrentViewModel = viewModel;
        }

        public void Close()
        {
            IsOpen = false;
            CurrentViewModel = null;
        }

        public void Hide()
        {
            IsOpen = false;
        }
    }
}
