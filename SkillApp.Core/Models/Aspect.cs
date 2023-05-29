using SkillApp.Core.Base;
using SkillApp.Core.Enums;
using System;

namespace SkillApp.Core.Models
{
    public class Aspect : VMBase, IAspect
    {
        public event ScoreChanged ScoreChangedEvent;
        private Action<IAspect> _removeAction;

        public event Action<AspectType> AspectTypeChangedEvent;
        private event Action<double, double> _scoreStepChanged;


        #region Properties


        private string _description;
        public string Description
        {
            get => _description; set
            {
                _description = value;
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

        private Enums.ExecutionFrequency _executionFrequency;
        public Enums.ExecutionFrequency ExecutionFrequency
        {
            get => _executionFrequency; set
            {
                _executionFrequency = value;
                OnPropertyChanged();
            }
        }

        private Enums.AspectType _type;
        public Enums.AspectType Type
        {
            get => _type; set
            {
                _type = value;
                AspectTypeChangedEvent?.Invoke(value);
                OnPropertyChanged();
            }
        }

        private Explanation _explanation;
        public Explanation Explanation
        {
            get => _explanation; set
            {
                _explanation = value;
                AspectTypeChangedEvent += value.OnTypeChanged;
                ScoreChangedEvent += value.OnScoreChanged;
                _scoreStepChanged += value.OnScoreStepChanged;
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

        private double _scoreStep = 0.1; 
        public double ScoreStep 
        {
            get => _scoreStep; set
            {
                _scoreStepChanged?.Invoke(_scoreStep, value);
                _scoreStep = value;
                OnPropertyChanged();
            }
        }

        private int _id;
        public int Id
        {
            get => _id; set
            {
                _id = value;
                OnPropertyChanged();
            }
        }


        #endregion Properties


        #region Constructors


        public Aspect() 
        {

        }

        public Aspect(Action<IAspect> removeAction)
        {
            _removeAction = removeAction;
        }


        #endregion Constructors


        #region Public Methods


        public void Remove()
        {
            _removeAction?.Invoke(this);
        }


        public void SetRemoveAction(Action<IAspect> removeAction)
        {
            if (_removeAction != null)
                return;
            _removeAction = removeAction;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is IAspect)) return -1;
            return ((IAspect)obj).Id.CompareTo(this.Id);
        }


        #endregion Public Methods
    }
}
