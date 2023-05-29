using System;
using System.Collections.Generic;

namespace SkillApp.Core.Models
{
    public interface ISkill : IScoreable, IComparable
    {
        /// <summary>
        /// 
        /// </summary>
        event Action<IAspect> AspectAdded;
        event Action<IAspect> AspectRemoved;
        event Action<string> NameChanged;

        bool IsEnabled { get; }

        /// <summary>
        /// Уникальный номер навыка
        /// </summary>
        int Id { get; set; }
        string Name { get; set; }
        double Score { get; set; }
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
