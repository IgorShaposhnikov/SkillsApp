using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SkillApp.Core.Models
{
    public class Skill : VMBase, ISkill
    {
        private readonly ObservableCollection<IAspect> _aspects = new ObservableCollection<IAspect>();
        public IEnumerable<IAspect> Aspects => _aspects;
        public int AspectCount { get => _aspects.Count; }


        #region Properties


        public int Id { get; }

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


        #endregion Properties


        public Skill(IEnumerable<IAspect> aspects = null)
        {
            if (aspects != null) 
            { 
                _aspects = new ObservableCollection<IAspect>(aspects);
            }
        }

        public void AddAspect(IAspect aspect)
        {
            _aspects.Add(aspect);
        }

        public void RemoveAspect(IAspect aspect) 
        {
            _aspects.Remove(aspect);
        }

        public void MoveAspectToAnotherSkill(ISkill newOwner, IAspect aspect)
        {
            throw new System.NotImplementedException();
        }
    }
}
