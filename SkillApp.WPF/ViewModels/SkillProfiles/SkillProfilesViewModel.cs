using SkillApp.Core.Models;
using SkillApp.WPF.Base;
using SkillApp.WPF.Base.Commands;
using SkillApp.WPF.Base.Store;
using SkillApp.WPF.ViewModels.Modal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SkillApp.WPF.ViewModels.SkillProfiles
{
    public sealed class SkillProfilesViewModel : VMBase
    {
        private readonly Action<VMBase> _changeCurrentPage;

        public ObservableCollection<ISkill> Skills { get; private set; } = new ObservableCollection<ISkill>();


        #region Commands


        private RelayCommand _openSkillFactoryCommand;
        public ICommand OpenSkillFactoryCommand
        {
            get => _openSkillFactoryCommand ?? (_openSkillFactoryCommand = new RelayCommand(obj =>
            {
                ModalNavigationStore.Instance.Open(new SkillFactoryModalViewModel(AddSkill));
            }));
        }

        private RelayCommand _openSkillEditModalCommand;
        public ICommand OpenSkillEditModalCommand
        {
            get => _openSkillEditModalCommand ?? (_openSkillEditModalCommand = new RelayCommand(obj =>
            {
                ModalNavigationStore.Instance.Open(new SkillEditModalViewModel((ISkill)obj));
            }));
        }

        private RelayCommand _deleteSkillCommand;
        public ICommand DeleteSkillCommand 
        {
            get => _deleteSkillCommand ?? (_deleteSkillCommand = new RelayCommand(obj => 
            {
                DeleleSkill((ISkill)obj);
            }));
        }


        private RelayCommand _showAspectsCommand;
        public ICommand ShowAspectsCommand 
        {
            get => _showAspectsCommand ?? (_showAspectsCommand = new RelayCommand(obj =>
            {
                var skill = (ISkill)obj;
                _changeCurrentPage(
                    new SkillAspectsViewModel(
                        () => { _changeCurrentPage(this); },
                        skill
                        )
                    );
            }));
        }


        #endregion Commands


        #region Constructors


        public SkillProfilesViewModel(Action<VMBase> changeCurrentPage, List<ISkill> skills = null)
        {
            _changeCurrentPage = changeCurrentPage;

            if (skills != null && skills.Count > 0)
            {
                LoadSkills(skills);
            }
        }


        #endregion Constructors


        public void LoadSkills(IEnumerable<ISkill> skills) 
        {
            if (Skills.Count == 0)
            {
                Skills = new ObservableCollection<ISkill>(skills);
            }
            else 
            {
                foreach (var wrapper in skills) 
                {
                    Skills.Add(wrapper);
                }
            }
        }

        private void AddSkill(ISkill skill) 
        {
            Skills.Add(skill);
        }

        private void DeleleSkill(ISkill ISkill) 
        {
            Skills.Remove(ISkill);
        }
    }
}
