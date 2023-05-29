using SkillApp.Core.Base;
using SkillApp.Core.Enums;
using SkillApp.Core.Models;
using SkillApp.WPF.Base.Modal;
using System;
using System.Text.RegularExpressions;

namespace SkillApp.WPF.ViewModels.SkillsProfile.Modal
{
    public sealed class AspectFactoryModalViewModel : ModalViewModelBase
    {
        #region ModalViewModelBase


        public override double Height => base.Height + 200;
        public override double Width => base.Width + 200;


        #endregion ModalViewModelBase


        private readonly string _skillName;
        private readonly IAspect _aspect;
        private readonly Action<IAspect> _addTo;
        private readonly int _count;

        private event Action<AspectType> _aspectTypeChanged;
        private event Action<double, double> _scoreChanged;
        private event Action<double, double> _scoreStepChanged;


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
                _scoreChanged?.Invoke(_score, value);
                _score = value;
                OnPropertyChanged();
            }
        }

        private ExecutionFrequency _executionFrequency;
        public ExecutionFrequency ExecutionFrequency
        {
            get => _executionFrequency; set
            {
                _executionFrequency = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// AspectType
        /// </summary>
        private Core.Enums.AspectType _type;
        public Core.Enums.AspectType Type
        {
            get => _type; set
            {
                _type = value;
                _aspectTypeChanged?.Invoke(value);
                if (Type == AspectType.Z) 
                {
                    Score = 0;
                } 
                else if (Type == AspectType.J) 
                {
                    Score = 3;
                }
                OnPropertyChanged();
            }
        }

        private Explanation _explanation;
        public Explanation Explanation
        {
            get => _explanation; set
            {
                _explanation = value;
                OnPropertyChanged();
            }
        }


        private double _stepScore = 0.1;
        public double ScoreStep
        {
            get => _stepScore; set
            {
                _scoreStepChanged?.Invoke(_stepScore, value);
                _stepScore = value;
                OnPropertyChanged();
            }
        }


        #endregion Properties


        /// TODO: придумать как обновить DefaultTextByType 
        public AspectFactoryModalViewModel(Action<IAspect> addTo, Action<IAspect> removeAction, int count, string skillName)
        {
            _skillName = skillName;
            _count = count;
            _addTo = addTo;
            _aspect = new Aspect(removeAction);
            ActionCommandAction += CreateAspect;
            Explanation = new Explanation(skillName);
            _aspectTypeChanged += Explanation.OnTypeChanged;
            _scoreChanged += Explanation.OnScoreChanged;
            _scoreStepChanged += Explanation.OnScoreStepChanged;
        }

        public void CreateAspect(object parameter) 
        {
            _aspect.Id = _count + 1;
            _aspect.Description = Description;
            _aspect.Score = Score;
            _aspect.ExecutionFrequency = ExecutionFrequency;
            _aspect.Type = Type;
            _aspect.ScoreStep = ScoreStep;
            _aspect.Explanation = Explanation;

            _addTo?.Invoke(_aspect);
        }
    }
}
