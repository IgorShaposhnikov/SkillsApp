using SkillApp.Core.Enums;

namespace SkillApp.Core.Models
{
    public interface IAspect
    {
        int Id { get; set; }
        string Description { get; set; }
        int Score { get; set; }
        ExecutionFrequency Frequency { get; set; }
        AspectType Type { get; set; }
        Explanation Explanation { get; set; }
    }
}
