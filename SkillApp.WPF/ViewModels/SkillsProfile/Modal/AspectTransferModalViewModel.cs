using SkillApp.Core.Base;
using SkillApp.Core.Models;
using SkillApp.WPF.Base.Commands;
using SkillApp.WPF.Base.Modal;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SkillApp.WPF.ViewModels.SkillsProfile.Modal
{
    public class AspectTransferWrapper : VMBase
    {
        public IAspect Aspect { get; }

        private bool _isSelected;
        public bool IsSelected 
        {
            get => _isSelected; set 
            {
                _isSelected= value;
                OnPropertyChanged();
            }
        }

        public AspectTransferWrapper(IAspect aspect)
        {
            Aspect = aspect;
        }
    }


    public class AspectTransferModalViewModel : ModalViewModelBase
    {
        #region ModalViewModelBase


        public override double Height => base.Height;
        public override double Width => base.Width;


        #endregion ModalViewModelBase


        private ISkill _aspectOwner;


        #region Properties


        private bool _isSelectedAll;
        public bool IsSelectedAll
        {
            get => _isSelectedAll; set 
            {
                _isSelectedAll = value;

                if (value) SelectAllAspects();
                else RemoveAllSelectAspects();

                OnPropertyChanged();
            }
        }


        // --- Skills --- //
        private ISkill _selectedSkill;
        public ISkill SelectedSkill
        {
            get => _selectedSkill; set 
            {
                _selectedSkill = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<ISkill> Skills { get; } = new ObservableCollection<ISkill>();

        // --- Aspects --- //
        public ObservableCollection<AspectTransferWrapper> Aspects { get; } = new ObservableCollection<AspectTransferWrapper>();


        #endregion Properties


        #region Constructors


        public AspectTransferModalViewModel(ISkill aspectOwner, ICollection<ISkill> skills) 
        {
            skills.Remove(aspectOwner);

            Skills = skills;
            foreach (var item in Skills)
            {
                SelectedSkill = item;
                break;
            }

            foreach (var aspect in aspectOwner.Aspects) 
            {
                Aspects.Add(new AspectTransferWrapper(aspect));
            }

            _aspectOwner = aspectOwner;
            ActionCommandAction += TransferAspects;
        }


        #endregion Constructors


        #region Private Methods


        private void TransferAspects(object parameters)
        {
            foreach (var wrapper in Aspects)
            {
                if (wrapper.IsSelected) 
                {
                    _aspectOwner.MoveAspectToAnotherSkill(SelectedSkill, wrapper.Aspect);
                }
            }
        }


        private void SelectAllAspects() 
        {
            foreach (var aspect in Aspects) 
            {
                aspect.IsSelected = true;
            }
        }

        private void RemoveAllSelectAspects() 
        {
            foreach (var aspect in Aspects)
            {
                aspect.IsSelected = false;
            }
        }


        #endregion Private Methods
    }
}
