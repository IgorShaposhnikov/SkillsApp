using SkillApp.Core.Models;
using SkillApp.WPF.Base.Modal;

namespace SkillApp.WPF.ViewModels.Modal
{
    public sealed class SkillEditModalViewModel : ModalViewModelBase
    {
        private readonly ISkill _skill;


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

        private int _score;
        public int Score 
        {
            get => _score; set 
            {
                _score = value;
                OnPropertyChanged();
            }
        }

        public SkillEditModalViewModel(ISkill skill)
        {
            _id = skill.Id;
            _name = skill.Name;
            _score = skill.Score;

            _skill = skill;
            ActionCommandAction += SaveChanges;
        }

        private void SaveChanges(object parameters)
        {
            _skill.Id = Id;
            _skill.Name = Name;
            _skill.Score = Score;
        }
    }
}
