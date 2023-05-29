using SkillApp.Core.Enums;
using System;
using System.Net.Http.Headers;

namespace SkillApp.Core.Printouts.Models
{
    [Serializable]
    public class Aspect : IComparable
    {
        public string Id { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Поля может и не быть, сделать checkbox на то, чтобы включать его в финальную таблицу или нет.
        /// </summary>
        public ExecutionFrequency ExecutionFrequency { get; set; }
        public double Score { get; set; }
        public Core.Enums.AspectType Type { get; set; }
        public Core.Printouts.Models.Explanation Explanation { get; set; }
        public bool IsEnabled { get; set; }
        public double ScoreStep { get; set; }

        public Aspect()
        {

        }

        public Aspect(Core.Models.IAspect aspect)
        {
            //Id = aspect.Id;
            Description = aspect.Description;
            Score = aspect.Score;
            ExecutionFrequency = aspect.ExecutionFrequency;
            Type = aspect.Type;
            Explanation = new Explanation(aspect.Explanation, aspect.Type);
            IsEnabled = aspect.IsEnabled;
        }

        public Aspect(int skillId, Core.Models.IAspect aspect)
        {
            Id = skillId + "." + aspect.Id;
            Description = aspect.Description;
            Score = aspect.Type == AspectType.J ? 3 : aspect.Score ;
            ExecutionFrequency = aspect.ExecutionFrequency;
            Type = aspect.Type;
            ScoreStep = aspect.ScoreStep;
            Explanation = new Explanation(aspect.Explanation, aspect.Type);
            IsEnabled = aspect.IsEnabled;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Aspect)) return -1;
            return ((Aspect)obj).Id.CompareTo(this.Id);
        }
    }
}
