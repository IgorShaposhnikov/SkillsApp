using SkillApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillApp
{
    public class Runtime
    {
        public static void Main(string[] args) 
        {
            var skill = new Skill();

            AddAspect(skill);

            foreach (var aspect in skill.Aspects)
            {
                Console.WriteLine(aspect.Description);
            }
        }

        public static void AddAspect(IAspectFactory aspectFactory)
        {
            aspectFactory.CreateAspect("test", 12, Core.Enums.ExecutionFrequency.EveryShift, Core.Enums.AspectType.B, "test1");
        }
    }
}
