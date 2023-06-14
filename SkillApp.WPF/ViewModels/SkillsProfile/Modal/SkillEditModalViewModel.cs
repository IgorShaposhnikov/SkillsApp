using SkillApp.Core.Models;
using SkillApp.WPF.Base.Modal;

namespace SkillApp.WPF.ViewModels.SkillsProfile.Modal
{
    public sealed class SkillEditModalViewModel : ModalViewModelBase
    {
        #region ModalViewModelBase


        public override double Height => base.Height;
        public override double Width => base.Width;


        #endregion ModalViewModelBase


        private readonly ISkill _skill;


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


        public SkillEditModalViewModel(ISkill skill)
        {
            _id = skill.Id;
            _name = skill.Name;

            _skill = skill;
            ActionCommandAction += SaveChanges;
        }


        #endregion Constructors


        #region Private Methods


        private void SaveChanges(object parameters)
        {
            _skill.Id = Id;
            _skill.Name = Name;
            //_skill.Score = Score;
        }


        #endregion Private Methods
    }
}
