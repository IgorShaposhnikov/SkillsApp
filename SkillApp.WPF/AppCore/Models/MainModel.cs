using System;
using System.Collections.ObjectModel;
using SkillApp.WPF.AppCore.Models.Table;
using SkillApp.WPF.AppModel;

namespace SkillApp.WPF.AppCore.Models
{
    public class MainModel : VMBase
    {
        public ObservableCollection<Skill> Skills { get; }

        private Skill _selectedSkill;
        public Skill SelectedSkill 
        {
            get => _selectedSkill; set 
            {
                _selectedSkill = value;
                OnPropertyChanged();
            }
        }

        public MainModel()
        {
            var random = new Random();
            Skills = new ObservableCollection<Skill>
            {
                new Skill("Организация производственного процесса", random.Next(1, 16)),
                new Skill("Чтение и понимание рабочей документации на изделие", random.Next(1, 16)),
                new Skill("Контроль и анализ эффективности технологического процесса", random.Next(1, 16)),
            };

            //for (var i = 0; i < 100; i++)
            //{
            //    Skills.Add(new Skill("Действия при возникновении аварийных ситуаций и для оказании первой помощи", random.Next(1, 16)));
            //}

            SelectedSkill = Skills[0];
        }
    }
}
