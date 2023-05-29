using SkillApp.Core.Models;
using SkillApp.WPF.Base;
using SkillApp.WPF.Base.Commands;
using SkillApp.WPF.Base.Store;
using SkillApp.WPF.ViewModels.Modal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Input;

namespace SkillApp.WPF.ViewModels.SkillProfiles
{
    public class SkillAspectsViewModel : VMBase
    {
        private readonly Action _backToOwner;
        private readonly ISkill _skill;

        public IEnumerable<IAspect> Aspects => _skill.Aspects;


        #region Commands


        private RelayCommand _addAspectCommand;
        public ICommand AddAspectCommand 
        {
            get => _addAspectCommand ?? (_addAspectCommand = new RelayCommand(obj => 
            {
                ModalNavigationStore.Instance.Open(new AspectFactoryModalViewModel());
            }));
        }

        private RelayCommand _backToOwnerCommand;
        public ICommand BackToOwnerCommand
        {
            get => _backToOwnerCommand ?? (_backToOwnerCommand = new RelayCommand(obj => 
            {
                _backToOwner?.Invoke();
            }));
        }


        #endregion Commands


        #region Constructors


        public SkillAspectsViewModel(Action backToOwner, ISkill owner)
        {
            _skill = owner;
            _backToOwner = backToOwner;
        }


        #endregion Constuctors
    }
}
