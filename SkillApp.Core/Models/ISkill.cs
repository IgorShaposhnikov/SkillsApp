using System.Collections.Generic;

namespace SkillApp.Core.Models
{
    public interface ISkill
    {
        /// <summary>
        /// Уникальный номер навыка
        /// </summary>
        int Id { get; set; }
        string Name { get; set; }
        int Score { get; set; }
        /// <summary>
        /// Список аспектов
        /// </summary>
        IEnumerable<IAspect> Aspects { get; }
        int AspectCount { get; }

        void AddAspect(IAspect aspect);
        void RemoveAspect(IAspect aspect);
        void MoveAspectToAnotherSkill(ISkill newOwner, IAspect aspect);
    }
}
