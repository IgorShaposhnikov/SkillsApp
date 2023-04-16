using System.Collections.Generic;
using SkillApp.WPF.AppModel;

namespace SkillApp.WPF.AppCore.Models.Table
{
    public sealed class Aspect : VMBase
    {
        private readonly static IDictionary<AspectType, IDictionary<ExecuteFrequency, string>> DefaultAspectTypeSentences
            = new Dictionary<AspectType, IDictionary<ExecuteFrequency, string>>()
            {
                {
                    AspectType.Z, new Dictionary<ExecuteFrequency, string>
                    {
                        { ExecuteFrequency.EveryShift, "Поставить ноль баллов за навык \"{0}\", если тестируемый допускает ошибку при определении условных обозначений, указанных в чертежах, или неправильно интерпретирует технические термины." },
                        { ExecuteFrequency.WhenSituationOccurs, "Поставить ноль баллов за навык \"{0}\", если тестируемый не может выполнить требуемых по инструкциям действий, либо выполняет их с нарушениями." },
                    }
                },
                {
                    AspectType.B, new Dictionary<ExecuteFrequency, string>
                    {
                        { ExecuteFrequency.EveryShift, "Some default Info" },
                        { ExecuteFrequency.WhenSituationOccurs, "Some default Info" }
                    }
                },
                {
                    AspectType.D, new Dictionary<ExecuteFrequency, string>
                    {
                        { ExecuteFrequency.EveryShift, "Some default Info" },
                        { ExecuteFrequency.WhenSituationOccurs, "Some default Info" }
                    }
                },
                {
                    AspectType.J, new Dictionary<ExecuteFrequency, string>
                    {
                        { ExecuteFrequency.EveryShift, "Some default Info" },
                        { ExecuteFrequency.WhenSituationOccurs, "Some default Info" }
                    }
                }
            };


        #region Properties


        private string _skillName;
        public string SkillName 
        {
            get => _skillName; set 
            {
                _skillName = value;
                OnPropertyChanged();
                UpdateExplanationWithDefaultAddtion();
            }
        }

        private ulong _id;
        public ulong Id
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

        private ulong _score;
        public ulong Score 
        {
            get => _score; set 
            {
                _score= value;
                OnPropertyChanged();
            }
        }

        private ExecuteFrequency _executeFrequency;
        public ExecuteFrequency ExecuteFrequency 
        {
            get => _executeFrequency; set 
            {
                _executeFrequency = value;
                OnPropertyChanged();
                UpdateExplanationWithDefaultAddtion();
            }
        }

        private AspectType _type;
        public AspectType Type 
        {
            get => _type; set 
            {
                _type = value;
                OnPropertyChanged();
                UpdateExplanationWithDefaultAddtion();
            }
        }

        private string _explanation;
        public string Explanation 
        {
            get => _explanation; set 
            {
                _explanation =  value;
                OnPropertyChanged();
            }
        }


        #endregion Properties


        #region Constructors


        public Aspect(ulong id, string description, ulong score, string explanation)
        {
            Id = id;
            Description = description;
            Score = score;
            _explanation = explanation;
        }


        #endregion Constructors


        #region Private Methods


        private void UpdateExplanationWithDefaultAddtion() 
        {
            if (!Explanation.Contains(DefaultAspectTypeSentences[Type][ExecuteFrequency]))
            {
                switch (Type) 
                {
                    case AspectType.Z:
                        Explanation = string.Format(DefaultAspectTypeSentences[Type][ExecuteFrequency], _skillName) + " " + Explanation;
                        break;
                    case AspectType.B:
                        break;
                    case AspectType.D:
                        break;
                    case AspectType.J:
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion Private Methods
    }
}
