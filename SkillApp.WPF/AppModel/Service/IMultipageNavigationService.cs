using System;

namespace SkillApp.WPF.AppModel.Service
{
    public interface IMultipageNavigationService
    {
        public VMBase CurrentViewModel { get; }
        void Navigate(VMBase viewModel);
    }
}
