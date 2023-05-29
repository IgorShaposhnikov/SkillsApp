using SkillApp.Core.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SkillApp.Core.Models
{
    public class SkillsProfile : VMBase
    {
        #region Properties


        private ObservableCollection<ISkill> _skills = new ObservableCollection<ISkill>();
        public IEnumerable<ISkill> Skills => _skills;


        private string _name = "Unknown";
        public string Name 
        {
            get => _name; set 
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private double _sumScore;
        public double SumScore 
        {
            get => _sumScore; private set 
            {
                _sumScore = value;
                OnPropertyChanged();
            }
        }

        private int _skillsCount;
        public int SkillsCount 
        {
            get => _skillsCount; private set 
            {
                _skillsCount = value;
                OnPropertyChanged();
            }
        }


        #endregion Properties


        #region Constructors


        public SkillsProfile()
        {
            SumScore = 0;
        }


        #endregion Constructors


        #region Public Methods


        public void AddSkill(ISkill skill) 
        {
            _skills.Add(skill);
            skill.ScoreChangedEvent += OnScoreChanged;
            SumScore += skill.Score;
            SkillsCount++;
        }

        public void Remove(ISkill skill) 
        {
            _skills.Remove(skill);
            skill.ScoreChangedEvent += OnScoreChanged;
            SumScore -= skill.Score;
            SkillsCount--;
            if (skill.Id != SkillsCount)
            {
                RecalculateIds();
            }
        }

        public void LoadSkills(IEnumerable<ISkill> skills)
        {
            if (_skills.Count == 0)
            {
                _skills = new ObservableCollection<ISkill>(skills);
            }
            else
            {
                foreach (var wrapper in skills)
                {
                    _skills.Add(wrapper);
                }
            }
        }

        private void OnScoreChanged(double oldValue, double newValue) 
        {
            if (SumScore > 0)
            {
                SumScore -= oldValue;
            }
            SumScore += newValue;
        }


        public IEnumerable<Skill> GetSkills() 
        {
            foreach (var skill in _skills) 
            {
                yield return (Skill)skill;
            }
        }


        public void MoveAspectToAnotherSkill(ISkill from, ISkill to, IAspect aspect) 
        {
            from.MoveAspectToAnotherSkill(to, aspect);
        }


        public void SortSkills() 
        {
            RecalculateIds();
            //var list = Skills.ToList<ISkill>();
            //list.Sort();
            //list.Reverse();
            //_skills = new ObservableCollection<ISkill>(list);
            //OnPropertyChanged(nameof(Skills));
        }

        public void RecalculateIds() 
        {
            var lastId = 0;
            foreach (var skill in _skills) 
            {
                if (skill.Id != lastId + 1) 
                {
                    skill.Id = lastId + 1;
                    lastId++;
                }
                
            }
        }

        #endregion Public Methods
    }
}
