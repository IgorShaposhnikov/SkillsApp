using SkillApp.WPF.Base.Modal;

namespace SkillApp.WPF.ViewModels.Modal
{
    public sealed class AspectEditModalViewModel : ModalViewModelBase
    {
        public AspectEditModalViewModel()
        {
            ActionCommandAction += SaveChanges;
        }

        private void SaveChanges(object parameters) 
        {
        
        }
    }
}
