using SkillApp.Core.Models;
using SkillApp.WPF.Base;
using SkillApp.WPF.Base.Commands;
using SkillApp.WPF.Base.Store;
using SkillApp.WPF.ViewModels.Modal;
using SkillApp.WPF.ViewModels.SkillsProfile.Modal;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace SkillApp.WPF.ViewModels.SkillsProfile
{
    public class SkillAspectsViewModel : VMBase
    {
        private readonly Action _backToOwner;
        private readonly ISkill _skill;
        private readonly Action<ISkill> _openAspectTransferModal;

        public IEnumerable<IAspect> Aspects => _skill.Aspects;

        private double _score;
        public double Score
        {
            get => _score; set
            {
                _score = value;
                OnPropertyChanged();
            }
        }

        private int _aspectsCount;
        public int AspectsCount
        {
            get => _aspectsCount; set
            {
                _aspectsCount = value;
                OnPropertyChanged();
            }
        }

        public string OwnerName { get => _skill.Name; }


        #region Commands


        private RelayCommand _addAspectCommand;
        public ICommand AddAspectCommand 
        {
            get => _addAspectCommand ?? (_addAspectCommand = new RelayCommand(obj => 
            {
                // TODO: Save ViewModel is Add aspect is not execute
                Console.WriteLine(_skill.Name);
                var vm = new AspectFactoryModalViewModel(_skill.AddAspect, _skill.RemoveAspect, _skill.AspectCount, _skill.Name);
                ModalNavigationStore.Instance.Open(vm);
                Score = _skill.Score;
            }));
        }

        private RelayCommand _removeAspectCommand;
        public ICommand RemoveAspectCommand
        {
            get => _removeAspectCommand ?? (_removeAspectCommand = new RelayCommand(obj => 
            {
                ModalNavigationStore.Instance.Open(new ModalDialogWindowViewModel(() =>
                {
                    var aspect = (IAspect)obj;
                    aspect.Remove();
                    Score = _skill.Score;
                },
                () => { },
                "Удаление аспекта",
                "Вы действительно хотите удалить аспект? \n Восстановить его будет невозможно!"
                ));
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

        private RelayCommand _editAspectModalCommand;
        public ICommand EditAspectModalCommand
        {
            get => _editAspectModalCommand ?? (_editAspectModalCommand = new RelayCommand(obj => 
            {
                ModalNavigationStore.Instance.Open(new AspectEditModalViewModel((IAspect)obj, _skill.Name));
            }));
        }


        private RelayCommand _selectAspectsByTransferCommand;
        public ICommand SelectAspectsByTransferCommand
        {
            get => _selectAspectsByTransferCommand ?? (_selectAspectsByTransferCommand = new RelayCommand(obj => 
            {
                _openAspectTransferModal(_skill);
            }));
        }


        #endregion Commands


        #region Constructors


        public SkillAspectsViewModel(Action backToOwner, ISkill owner, Action<ISkill> openAspectTransferModal)
        {
            _openAspectTransferModal = openAspectTransferModal;
            _skill = owner;
            _backToOwner = backToOwner;
            foreach (var aspect in _skill.Aspects)
            {
                Score += aspect.Score;    
            }
            
            AspectsCount = owner.AspectCount;
            owner.AspectAdded += OnAspectAdded;
            owner.AspectRemoved += OnAspectRemoved;
        }


        #endregion Constuctors


        #region Private Methods


        private void OnAspectAdded(IAspect aspect) 
        {
            Score += aspect.Score;
            AspectsCount++;
        }

        private void OnAspectRemoved(IAspect aspect) 
        {
            Score -= aspect.Score;
            AspectsCount--;
        }

        // может сделать обертку при добавлении аспекта в навык, на случай добавления в будущем функционала.


        #endregion Private Methods
    }
}
