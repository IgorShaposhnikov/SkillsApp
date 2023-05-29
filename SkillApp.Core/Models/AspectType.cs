namespace SkillApp.Core.Models
{
    public class AspectType
    {
        public int Id { get; }
        public string Name { get; }
        public string Description { get; }

        public AspectType(int id, string name, string description) 
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
