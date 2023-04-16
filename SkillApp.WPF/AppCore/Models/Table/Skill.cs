using System.Collections.ObjectModel;
using SkillApp.WPF.AppModel;

namespace SkillApp.WPF.AppCore.Models.Table
{
    public sealed class Skill : VMBase
    {
        private static ulong _skillsCount = 1;


        #region Properties

        public ObservableCollection<Aspect> Aspects { get; }

        private ulong _id;
        public ulong Id 
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
                OnNameChanged();
            }
        }

        private float _score;
        public float Score 
        {
            get => _score; set 
            {
                _score= value;
                OnPropertyChanged();
            }
        }


        #endregion Properties


        private ulong _aspectCount = 1;


        #region Constructors


        private readonly string g = "";//"В данном случае префикс local ссылается на пространство имен текущего проекта, в котором определен класс Phone (xmlns:local=\"clr-namespace:Controls\"), а col - префикс-ссылка на пространство имен System.Collections (xmlns:col=\"clr-namespace:System.Collections;assembly=mscorlib\"). И это даст в итоге следующий вывод:";


        public Skill(string name, float score)
        {
            Aspects = new ObservableCollection<Aspect>()
            {
                new Aspect(1, "Прием-передача смены от мастера мастеру", (ulong)score, g),
                new Aspect(2, "Проведение оперативного совещания с рабочими и бригадирами перед началом смены", (ulong)score, g),
                new Aspect(3, "Информирование рабочих о плановых показателях производственного процесса, о текущих проблемах с качеством с использованием данных Сводного интерактивного отчета по Службе качества", (ulong)score, g)
            };
            _aspectCount = 4;

            for (var i = 0; i < 1000; i++)
            {
                Aspects.Add(new Aspect(_aspectCount, "Информирование рабочих о плановых показателях производственного процесса, о текущих проблемах с качеством с использованием данных Сводного интерактивного отчета по Службе качества", (ulong)score, g));
                _aspectCount++;
            }

            Id = _skillsCount;
            Name = name;
            Score = score;

            _skillsCount++;
        }


        #endregion Constructors


        #region Private Methods


        private void OnNameChanged() 
        {
            foreach (var aspect in Aspects)
            {
                aspect.SkillName = _name;
            }
        }


        #endregion Private Methods
    }
}
