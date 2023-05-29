using SkillApp.Core.Models;
using System;
using System.Linq;

namespace SkillApp.Core.Printouts.Models
{
    [Serializable]
    public class Skill : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }
        public Aspect[] Aspects { get; set; }
        public bool IsEnabled { get; set; }


        public Skill()
        {
            
        }

        public Skill(ISkill skill)
        {
            Id = skill.Id;
            Name = skill.Name;
            Score = skill.Score;

            var arrAspects = skill.Aspects.ToArray();
            Aspects = new Aspect[arrAspects.Length];
            for (var i = 0; i < arrAspects.Length; i++) 
            {
                Aspects[i] = new Aspect(skill.Id, arrAspects[i]);
            }
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Skill)) return -1;
            return ((Skill)obj).Id.CompareTo(this.Id);
        }
    }
}
