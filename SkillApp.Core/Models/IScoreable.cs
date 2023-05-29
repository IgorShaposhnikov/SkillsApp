namespace SkillApp.Core.Models
{
    public delegate void ScoreChanged(double oldValue, double newValue);

    public interface IScoreable
    {
        event ScoreChanged ScoreChangedEvent;
    }
}
