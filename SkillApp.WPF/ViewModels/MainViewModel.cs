using SkillApp.WPF.Base;
using SkillApp.WPF.Base.Store;

namespace SkillApp.WPF.ViewModels
{
    public class MainViewModel : VMBase
    {
        private readonly MainMenuViewModel _mainMenuViewModel;

        public INavigationStore NavigationStore { get; } = new NavigationStore();
        public IModalNavigationStore ModalNavigationStore => Base.Store.ModalNavigationStore.Instance;
        public VMBase CurrentViewModel => NavigationStore.CurrentViewModel;


        public MainViewModel() 
        {
            _mainMenuViewModel = new MainMenuViewModel();
            NavigationStore.CurrentViewModelChanged += NavigationStore_CurrentViewModelChanged;
            NavigationStore.CurrentViewModel = _mainMenuViewModel;

        }


        #region NavigationStore Actions


        private void NavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }


        #endregion NavigationStore Actions


        #region Public Methods


        public void LoadXmlProject(string path) 
        {
            _mainMenuViewModel.LoadXmlSkillsProfile(path);  
        }

        public void LoadExcelProject(string path) 
        {
            _mainMenuViewModel.LoadExcelSkillsProfile(path);
        }


        #endregion Public Methods
    }
}
