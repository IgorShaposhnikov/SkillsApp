using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillApp.WPF.AppModel;

namespace SkillApp.WPF.AppCore.Models
{
    public class SkillFactoryModel : VMBase
    {
        #region Properties


        private string _name;
        public string Name 
        {
            get => _name; set 
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private float _score = 0.0f;
        public float Score 
        {
            get => _score; set 
            {
                _score = value;
                OnPropertyChanged();
            }
        }


        #endregion Properties


        #region Constructors


        public SkillFactoryModel()
        {
            
        }


        #endregion Constructors
    }
}
