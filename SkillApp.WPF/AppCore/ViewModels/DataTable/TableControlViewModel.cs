using SkillApp.WPF.AppModel;
using SkillApp.WPF.AppModel.Service;

namespace SkillApp.WPF.AppCore.ViewModels.DataTable
{
    public class TableControlViewModel : VMBase
    {
        private readonly MultipageNavigationService _multipageNavigationService = new();
        public VMBase CurrentViewModel => _multipageNavigationService.CurrentViewModel;

        public TableControlViewModel(MainViewModel mainViewModel)
        {
            _multipageNavigationService.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _multipageNavigationService.Navigate(new SkillDataTableViewModel(_multipageNavigationService, mainViewModel.Model.Skills));
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
