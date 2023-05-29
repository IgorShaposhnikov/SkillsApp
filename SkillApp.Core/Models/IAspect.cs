using SkillApp.Core.Enums;
using System;

namespace SkillApp.Core.Models
{
    public interface IAspect : IScoreable, IComparable
    {
        event Action<AspectType> AspectTypeChangedEvent;

        bool IsEnabled { get; }
        int Id { get; set; }
        string Description { get; set; }
        double Score { get; set; }
        double ScoreStep { get; set; }
        ExecutionFrequency ExecutionFrequency { get; set; }
        Core.Enums.AspectType Type { get; set; }
        Explanation Explanation { get; set; }

        void Remove();
    }
}
