using SkillApp.Core.Enums;
using SkillApp.Core.Models;
using SkillApp.WPF.Base.Commands;
using SkillApp.WPF.Base.Modal;
using System.Windows.Input;

namespace SkillApp.WPF.ViewModels.SkillsProfile.Modal
{
    public sealed class AspectEditModalViewModel : ModalViewModelBase
    {
        #region ModalViewModelBase


        public override double Height => base.Height + 100;
        public override double Width => base.Width + 100;


        #endregion ModalViewModelBase


        private readonly IAspect _aspect;
        private readonly string _skillName;


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
                Explanation?.OnScoreChanged(_score, value);
                _score = _score = value;
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

        private Core.Enums.AspectType _type;
        public Core.Enums.AspectType Type 
        { 
            get => _type; set 
            {
                _type = value;
                Explanation?.OnTypeChanged(value);
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
                Explanation?.OnScoreStepChanged(_stepScore, value);
                _stepScore = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties


        public AspectEditModalViewModel(IAspect aspect, string skillName = "")
        {
            _aspect = aspect;
            
            Description = _aspect.Description;
            Score = _aspect.Score;
            ExecutionFrequency = _aspect.ExecutionFrequency;
            Type = _aspect.Type;
            ScoreStep = aspect.ScoreStep;
            Explanation = _aspect.Explanation;
            Explanation.OnSkillNameChanged(skillName);


            ActionCommandAction += SaveChanges;
        }

        private void SaveChanges(object parameters) 
        {
            _aspect.Description = Description;
            _aspect.Score = Score;
            _aspect.ExecutionFrequency = ExecutionFrequency;
            _aspect.Type = Type;
            _aspect.Explanation = Explanation;
        }
    }
}
