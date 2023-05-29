using SkillApp.Core.Enums;
using System;
using System.Reflection.Emit;

namespace SkillApp.Core.Printouts.Models
{
    [Serializable]
    public class Explanation
    {
        public string ResultString
        {
            get; set;
        }

        public string Preamble { get; set; }
        public string UserInput { get; set; }
        public string UserInput1 { get; set; }
        public string UserInput2 { get; set; }
        public string UserInput3 { get; set; }

        public AspectType Type { get; set; }

        public Explanation()
        {
            
        }

        public Explanation(Core.Models.Explanation explanation, AspectType type)
        {
            ResultString = explanation.ResultString;
            Preamble = explanation.Preamble;
            UserInput = explanation.UserInput;
            UserInput1 = explanation.UserInput1;
            UserInput2 = explanation.UserInput2;
            UserInput3 = explanation.UserInput3;
            Type = type;
        }
    }
}
