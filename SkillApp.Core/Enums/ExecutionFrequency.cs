using System.ComponentModel;

namespace SkillApp.Core.Enums
{
    public enum ExecutionFrequency
    {
        [Description("-")]
        None,
        [Description("Каждую смену")]
        EveryShift,
        [Description("При возникновении данной ситуации")]
        WhenSituationOccurs
    }
}
