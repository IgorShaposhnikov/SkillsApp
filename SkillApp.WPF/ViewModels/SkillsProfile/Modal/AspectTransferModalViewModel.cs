using SkillApp.Core.Models;
using SkillApp.WPF.Base.Modal;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SkillApp.WPF.ViewModels.SkillsProfile.Modal
{
    public class AspectTransferWrapper 
    {
        private ICollection<IAspect> _selectedItems;

        public IAspect Aspect { get; }

        private bool _isSelected;
        public bool IsSelected 
        { 
            get => _isSelected; set 
            {
                _isSelected= value;

                if (value) _selectedItems.Add(Aspect);
                else _selectedItems.Remove(Aspect);
            }
        }

        public AspectTransferWrapper(IAspect aspect, ref ICollection<IAspect> selectedItems)
        {
            Aspect = aspect;
            _selectedItems = selectedItems;
        }
    }


    public class AspectTransferModalViewModel : ModalViewModelBase
    {
        #region ModalViewModelBase


        public override double Height => base.Height + 100;
        public override double Width => base.Width + 100;


        #endregion ModalViewModelBase


        private ISkill _aspectOwner;
        private readonly IEnumerable<ISkill> _skills;

        private IEnumerable<IAspect> _notAllSelectedAspects = new ObservableCollection<IAspect>();


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

        private readonly ICollection<IAspect> _selectedAspects = new ObservableCollection<IAspect>();
        public IEnumerable<IAspect> SelectedAspects { get => _selectedAspects; }


        #endregion Properties


        #region Constructors


        public AspectTransferModalViewModel(ISkill aspectOwner, ICollection<ISkill> skills) 
        {
            skills.Remove(aspectOwner);
            _skills = skills;

            Skills = skills;
            foreach (var item in Skills)
            {
                SelectedSkill = item;
                break;
            }

            foreach (var aspect in aspectOwner.Aspects) 
            {
                Aspects.Add(new AspectTransferWrapper(aspect, ref _selectedAspects));
            }

            _aspectOwner = aspectOwner;
            ActionCommandAction += TransferAspects;
        }


        #endregion Constructors


        #region Private Methods


        private void TransferAspects(object parameters)
        {
            foreach (var wrapper in SelectedAspects)
            {
                _aspectOwner.MoveAspectToAnotherSkill(SelectedSkill, wrapper);
            }
        }


        private void SelectAllAspects() 
        {
            _notAllSelectedAspects = SelectedAspects;
            foreach (var aspect in _aspectOwner.Aspects) 
            { 
                _selectedAspects.Add(aspect);
            }
        }

        private void RemoveAllSelectAspects() 
        {
            _selectedAspects.Clear();
            foreach (var aspect in _notAllSelectedAspects) 
            {
                _selectedAspects.Add(aspect);
            }
        }

        #endregion Private Methods
    }
}
