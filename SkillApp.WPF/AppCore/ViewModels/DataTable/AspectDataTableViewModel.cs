using System.Collections.Generic;
using System.Collections.ObjectModel;
using SkillApp.WPF.AppCore.Models.Table;
using SkillApp.WPF.AppModel.Service;

namespace SkillApp.WPF.AppCore.ViewModels.DataTable
{
    public class AspectDataTableViewModel : TableControlContentViewModelBase
    {
        private readonly IEnumerable<Skill> _skills;

        private ObservableCollection<Aspect> _aspects;
        public IEnumerable<Aspect> Aspects { get => _aspects; }

        public AspectDataTableViewModel(IMultipageNavigationService _multipageNavigationService, IEnumerable<Skill> skills, Skill skill) 
            : base(_multipageNavigationService)
        {
            _skills = skills;
            _aspects = skill.Aspects;
        }

        private RelayCommand _backToSkillsTableCommand;
        public RelayCommand BackToSkillsTableCommand
        {
            get => _backToSkillsTableCommand ??= new RelayCommand(obj =>
            {
                //var skill = (Skill)obj;
                //skill.Aspects();
                _multipageNavigationService.Navigate(new SkillDataTableViewModel(_multipageNavigationService, _skills));
            });
        }

        private RelayCommand _removeAspectCommand;
        public RelayCommand RemoveAspectCommand 
        {
            get => _removeAspectCommand ??= new RelayCommand(obj => 
            {
                var aspect = obj as Aspect;
                _aspects.Remove(aspect);
            });
        }
    }
}
