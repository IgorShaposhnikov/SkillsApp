using SkillApp.Core.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SkillApp.Core.Models
{
    public class Skill : VMBase, ISkill
    {
        public event ScoreChanged ScoreChangedEvent;
        public event Action<IAspect> AspectAdded;
        public event Action<IAspect> AspectRemoved;
        public event Action<string> NameChanged;

        private readonly ObservableCollection<IAspect> _aspects = new ObservableCollection<IAspect>();


        #region Properties


        public IEnumerable<IAspect> Aspects => _aspects;
        public int AspectCount { get => _aspects.Count; }

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
                NameChanged?.Invoke(value);
                OnPropertyChanged();
            }
        }

        private double _score;
        public double Score
        {
            get => _score; set
            {
                ScoreChangedEvent?.Invoke(_score, value);
                _score = value;
                OnPropertyChanged();
            }
        }

        private bool _isEnabled = true;
        public bool IsEnabled 
        {
            get => _isEnabled; set 
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties


        #region Constructors

        
        public Skill(IEnumerable<IAspect> aspects = null)
        {
            if (aspects != null) 
            { 
                _aspects = new ObservableCollection<IAspect>(aspects);
            }
        }


        #endregion Constructors


        #region Public & Protected Methods


        public void AddAspect(IAspect aspect)
        {
            _aspects.Add(aspect);
            aspect.ScoreChangedEvent += OnAspectScoreChanged;
            Score += aspect.Score;
            AspectAdded?.Invoke(aspect);
        }

        public void RemoveAspect(IAspect aspect) 
        {
            _aspects.Remove(aspect);
            aspect.ScoreChangedEvent -= OnAspectScoreChanged;
            Score -= aspect.Score;
            AspectRemoved?.Invoke(aspect);
        }

        public void MoveAspectToAnotherSkill(ISkill to, IAspect aspect)
        {
            RemoveAspect(aspect);
            to.AddAspect(aspect);
        }

        public int CompareTo(object obj)
        {
            if (!(obj is ISkill)) return -1;
            return ((ISkill)obj).Id.CompareTo(this.Id);
        }


        #endregion Public & Protected Methods


        #region Private Methods


        private void OnAspectScoreChanged(double oldValue, double newValue) 
        {
            Console.WriteLine(oldValue.ToString(), newValue.ToString());
            Score -= oldValue;
            Score += newValue;
        }


        #endregion Private Methods
    }
}
