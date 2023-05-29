using SkillApp.Core;
using SkillApp.Core.Abstraction;
using SkillApp.Core.Models;
using SkillApp.WPF.Base.Modal;
using System;

namespace SkillApp.WPF.ViewModels.Modal
{
    public sealed class SkillFactoryModalViewModel : ModalViewModelBase
    {
        private readonly Action<ISkill> _addTo;
        private readonly Factory _factory = new Factory();

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

        public SkillFactoryModalViewModel(Action<ISkill> addTo)
        {
            _addTo = addTo;
            ActionCommandAction += CreateSkill;
        }

        private void CreateSkill(object parameter) 
        {
            var newSkill = _factory.CreateSkill(Name, Score);
            _addTo(newSkill);
        }
    }
}
