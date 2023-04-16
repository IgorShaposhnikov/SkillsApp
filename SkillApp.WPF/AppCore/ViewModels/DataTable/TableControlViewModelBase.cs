using SkillApp.WPF.AppModel;
using SkillApp.WPF.AppModel.Service;

namespace SkillApp.WPF.AppCore.ViewModels.DataTable
{
    public abstract class TableControlContentViewModelBase : VMBase
    {
        protected readonly IMultipageNavigationService _multipageNavigationService;

        public TableControlContentViewModelBase(IMultipageNavigationService multipageNavigationService)
        {
            _multipageNavigationService = multipageNavigationService;
        }
    }
}
