using SkillApp.Core.Printouts.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace SkillApp.Core.Printouts
{
    public class XMLPrintout
    {
        public static void SaveSkillProfile(Core.Models.SkillsProfile skillProfile, string path) 
        {
            var xmlSkillSerializer = new XmlSerializer(typeof(List<Models.Skill>));

            var test = ISkillToSkill(skillProfile.Skills);
            using (var fs = new FileStream(string.Format("{0}\\{1}-{2}.xml", path, skillProfile.Name, DateTime.Now.ToString().Replace(':', '-')), FileMode.Create)) 
            {
                xmlSkillSerializer.Serialize(fs, test);
            }
        }

        private static List<Skill> LoadSkillProfileNotSorted(string path)
        {
            var xmlSkillSerializer = new XmlSerializer(typeof(List<Models.Skill>));
            var result = new List<Skill>();
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                result = xmlSkillSerializer.Deserialize(fs) as List<Skill>;
                if (result == null)
                {
                    new Exception("Cannot read file");
                }
            }
            return result;
        }

        // TODO: Перенести в отдельный класс
        public static List<Skill> LoadSkillProfile(string path = "")
        {
            var result = LoadSkillProfileNotSorted(path);

            result.Sort();
            result.Reverse();

            foreach (var item in result) 
            {
                Array.Sort(item.Aspects);
                Array.Reverse(item.Aspects);
            }

            return result;
        }

        private static List<Skill> ISkillToSkill(IEnumerable<Core.Models.ISkill> skills) 
        {
            var list = new List<Skill>();
            var lastId = 0;
            foreach (var skill in skills) 
            {
                if (lastId + 1 != skill.Id) 
                {
                    skill.Id = lastId + 1;
                }
                lastId++;
                if (skill.IsEnabled) { 
                    list.Add(new Skill(skill));
                }
            }

            foreach (var skill in list) 
            {
                skill.Aspects = skill.Aspects.Where(i => i.IsEnabled).ToArray<Aspect>();
            }
            return list;
        }
    }
}
