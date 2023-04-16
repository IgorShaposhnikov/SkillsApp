using SkillApp.WPF.AppCore.Models;
using NightWorld.AppModel.Stores;
using System;
using SkillApp.WPF.AppCore.Models.Table;
using SkillApp.WPF.AppCore.ViewModels.DataTable;
using SkillApp.WPF.AppModel;
using SkillApp.WPF.Controls.Modal;
using SkillApp.WPF.AppCore.ViewModels.Modal;

namespace SkillApp.WPF
{
    public class MainViewModel : VMBase
    {
        #region Navigation
        
        
        private static readonly NavigationStore _navigationStore = new();
        private static readonly ModalNagivationStore _modalNavigationStore = new();

        
        public VMBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public VMBase ModalCurrentViewModel => _modalNavigationStore.CurrentViewModel;
        public bool IsOpen => _modalNavigationStore.IsOpen;

        public static IModalController ModalController { get; } = new ModalController();


        #endregion Navigation


        public MainModel Model { get; }

        public Action<Skill> SelectedSkillChanged;


        public MainViewModel()
        {
            Model = new MainModel();
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _modalNavigationStore.CurrentViewModelChanged += OnCurrentModalViewModelChanged;

            _navigationStore.CurrentViewModel = new TableControlViewModel(this);
        }

        private void OnCurrentViewModelChanged() 
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void OnCurrentModalViewModelChanged()
        {
            OnPropertyChanged(nameof(ModalCurrentViewModel));
        }
    }
}
