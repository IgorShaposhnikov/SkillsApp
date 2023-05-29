using SkillApp.Core.Enums;
using SkillApp.Core.Models;
using SkillApp.WPF.Base.Modal;

namespace SkillApp.WPF.ViewModels.Modal
{
    public sealed class AspectFactoryModalViewModel : ModalViewModelBase
    {
        #region ModalViewModelBase


        public override double Height => base.Height + 100;
        public override double Width => base.Width + 100;


        #endregion ModalViewModelBase


        private readonly IAspect _aspect;


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

        private int _score;
        public int Score
        {
            get => _score; set
            {
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
                OnPropertyChanged();
            }
        }

        private string _preamble;
        public string Preamble
        {
            get => _preamble; set
            {
                _preamble = value;
                OnPropertyChanged();
            }
        }

        private string _customText;
        public string CustomText
        {
            get => _customText; set
            {
                _customText = value;
                OnPropertyChanged();
            }
        }


        #endregion Properties


        public AspectFactoryModalViewModel()
        {
            ActionCommandAction += CreateAspect;
        }

        public void CreateAspect(object parameter) 
        {
            _aspect.Description = Description;
            _aspect.Score = Score;
            _aspect.Frequency = ExecutionFrequency;
            _aspect.Type = Type;
            _aspect.Explanation = new Explanation();
        }
    }
}
