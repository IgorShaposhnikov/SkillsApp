using SkillApp.Core.Models;
using SkillApp.WPF.Base.Modal;
using System;

namespace SkillApp.WPF.ViewModels.SkillsProfile.Modal
{
    public sealed class SkillFactoryModalViewModel : ModalViewModelBase
    {
        #region ModalViewModelBase


        public override double Height => base.Height + 100;
        public override double Width => base.Width + 100;


        #endregion ModalViewModelBase


        private readonly Action<ISkill> _addTo;
        private readonly int _count;


        #region Properties


        private int _id;
        public int Id 
        {
            get => _id; set 
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get => _name; set
            {
                _name = value;
                OnPropertyChanged();
            }
        }


        #endregion Properties


        #region Constructors


        public SkillFactoryModalViewModel(Action<ISkill> addTo, int count)
        {
            _count = count;
            _addTo = addTo;
            ActionCommandAction += CreateSkill;
        }


        #endregion Constructors


        #region Private Methods


        private void CreateSkill(object parameter) 
        {
            var newSkill = new Skill()
            {
                Id = _count + 1,
                Name = _name,
                Score = 0
            };
            _addTo(newSkill);
        }


        #endregion Private Methods
    }
}
