using System.ComponentModel;

namespace SkillApp.WPF.AppCore.Models.Table
{
    public enum ExecuteFrequency
    {
        [Description("Каждую смену")]
        EveryShift,
        [Description("При возникновении данной ситуации")]
        WhenSituationOccurs
    }
}
