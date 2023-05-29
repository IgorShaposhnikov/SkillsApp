using SkillApp.Core.Base;

namespace SkillApp.Core.Models
{
    public class Explanation : VMBase
    {
        private string _preamble;
        public string Preamble 
        {
            get => _preamble; set 
            {
                _preamble = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get => _description; set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
    }
}
