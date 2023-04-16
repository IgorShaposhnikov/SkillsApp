using NightWorld.AppModel.Stores;
using System;

namespace SkillApp.WPF.AppModel.Service
{
    public class NavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<VMBase> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<VMBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
