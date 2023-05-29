using SkillApp.Core.Base;
using SkillApp.Core.Enums;
using SkillApp.Core.Printouts.Models;
using System;
using System.Text.RegularExpressions;

namespace SkillApp.Core.Models
{
    [Serializable]
    public class Explanation : VMBase
    {
        private string _skillName;
        private double _currentScore = 0;
        private double _currentScoreStep = 0.1;
        private AspectType _currentType;


        public string ResultString
        {
            get => GetResultString();
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

        private string _defaultText;
        public string DefaultText
        {
            get => _defaultText; set
            {
                _defaultText = value;
                OnPropertyChanged();
            }
        }

        private string _userInput = "";
        public string UserInput
        {
            get => _userInput; set
            {
                _userInput = value;
                DefaultText = GetDefaultTextByType(_currentType);
                OnPropertyChanged();
            }
        }

        private string _userInput1 = "";
        public string UserInput1
        {
            get => _userInput1; set
            {
                _userInput1 = value;
                OnPropertyChanged();
            }
        }

        private string _userInput2 = "";
        public string UserInput2
        {
            get => _userInput2; set
            {
                _userInput2 = value;
                OnPropertyChanged();
            }
        }

        private string _userInput3 = "";
        public string UserInput3
        {
            get => _userInput3; set
            {
                _userInput3 = value;
                OnPropertyChanged();
            }
        }

        #region Constructors


        public Explanation(string skillName)
        {
            _skillName = skillName;
            OnTypeChanged(_currentType);
        }

        public Explanation(AspectType aspectType = AspectType.Z)
        {
            OnTypeChanged(aspectType);
        }

        public Explanation(Core.Printouts.Models.Explanation explanation, AspectType type, double score, double scoreStep)
        {
            Preamble = explanation.Preamble;
            UserInput = explanation.UserInput;
            UserInput1 = explanation.UserInput1;
            UserInput2 = explanation.UserInput2;
            UserInput3 = explanation.UserInput3;
            OnTypeChanged(type);
            OnScoreChanged(0, score);
            OnScoreStepChanged(0.1, scoreStep);
        }


        #endregion Constructors


        #region Public Methods


        public void OnSkillNameChanged(string newName) 
        {
            _skillName = newName;
            GetDefaultTextByType(_currentType);
        }


        public void OnScoreChanged(double oldValue, double newValue)
        {
            _currentScore = newValue;
            var regex = new Regex(Regex.Escape(" " + oldValue + ":"));
            DefaultText = regex.Replace(DefaultText, " " + newValue + " ", 1);
        }

        public void OnScoreStepChanged(double oldValue, double newValue)
        {
            _currentScoreStep = newValue;
            var regex = new Regex(Regex.Escape(" " + oldValue + " "));
            DefaultText = regex.Replace(DefaultText, " " + newValue + " ", 1);
        }

        public void OnTypeChanged(AspectType type)
        {
            Console.WriteLine(type);
            _currentType = type;
            DefaultText = GetDefaultTextByType(type);
        }


        #endregion Public Methods


        #region Default Texts

        private string GetDefaultTextByType(AspectType type)
        {
            switch (type)
            {
                case AspectType.Z:
                    return "Поставить 0 (ноль) баллов за навык “" + _skillName + "” если тестируемый ___.";
                case AspectType.B:
                    return "Начислить баллы в количестве, равном весу аспекта в баллах, если тестируемый ___. В случае несоблюдения данного условия поставить ноль баллов за аспект.";
                case AspectType.D:
                    return "Начислить по " + _currentScoreStep + " балла, но не более " + _currentScore + ": ___";
                case AspectType.J:
                    return "Начислить: \r\n- 3 балла, если ___; \r\n- 2 балла, если ___; \r\n- 1 балл, если ___; \r\n- 0 баллов, если ___.";
                default:
                    return "";
            }
        }

        private string GetResultString() 
        {
            var preamblePrepare = Preamble + "\n";
            if (string.IsNullOrEmpty(Preamble)) 
            {
                preamblePrepare = "";
            }

            switch (_currentType)
            {
                case AspectType.Z:
                    return preamblePrepare + "Поставить 0 (ноль) баллов за навык “" + _skillName + "” если тестируемый " + UserInput + ".";
                case AspectType.B:
                    return preamblePrepare + "Начислить баллы в количестве, равном весу аспекта в баллах, если тестируемый " + UserInput + ". В случае несоблюдения данного условия поставить 0 (ноль) баллов за аспект.";
                case AspectType.D:
                    return preamblePrepare + "Начислить по " + _currentScoreStep + " балла, но не более " + _currentScore + " балла(ов) \n" + UserInput;
                case AspectType.J:
                    return preamblePrepare + "Начислить: \r\n- 3 балла, если " + UserInput + " ; \r\n- 2 балла, если " + UserInput1 + "; \r\n- 1 балл, если " + UserInput2 + "; \r\n- 0 баллов, если " + UserInput3 + ".";
                default:
                    return "";
            }
        }


        #endregion Default Texts
    }
}