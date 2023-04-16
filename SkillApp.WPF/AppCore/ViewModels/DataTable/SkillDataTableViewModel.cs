using SkillApp.WPF.AppCore.ViewModels.Modal;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SkillApp.WPF.AppCore.Models.Table;
using SkillApp.WPF.AppModel.Service;

namespace SkillApp.WPF.AppCore.ViewModels.DataTable
{
    public class SkillDataTableViewModel : TableControlContentViewModelBase
    {
        public ObservableCollection<Skill> Skills { get; }

        public SkillDataTableViewModel(IMultipageNavigationService multipageNavigationService, IEnumerable<Skill> skills) 
            : base(multipageNavigationService)
        {
            Skills = new ObservableCollection<Skill>(skills);
        }


        #region Commands


        private RelayCommand _showSkillAspectsCommand;
        public RelayCommand ShowSkillAspectsCommand
        {
            get => _showSkillAspectsCommand ??= new RelayCommand(obj =>
            {
                _multipageNavigationService.Navigate(new AspectDataTableViewModel(_multipageNavigationService, Skills, (Skill)obj));
            });
        }


        private RelayCommand _addSkillCommand;
        public RelayCommand AddSkillCommand 
        {
            get => _addSkillCommand ??= new RelayCommand(obj => 
            {
                MainViewModel.ModalController.Open(new SkillFactoryViewModel());
            });
        }


        #endregion Commands
    }
}
