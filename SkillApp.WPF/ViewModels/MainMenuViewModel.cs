using SkillApp.WPF.Base;
using SkillApp.WPF.Base.Commands;
using SkillApp.WPF.Base.Store;
using SkillApp.WPF.ViewModels.SkillProfiles;
using System;
using System.Collections.ObjectModel;

namespace SkillApp.WPF.ViewModels
{
    public class Tab<T>
    {
        private readonly Action<Tab<T>> _onCurrentTabChanged;


        #region Properties


        public string Name { get; }

        public int Id { get; }

        public T Content { get; set; }

        public bool IsChecked { get; set; }

        public bool IsEnable { get; set; } = true;


        #endregion Properties


        private RelayCommand _changedTabCommand;
        public RelayCommand ChangedTabCommand
        {
            get => _changedTabCommand ?? (_changedTabCommand = new RelayCommand(obj =>
            {
                var tab = (Tab<T>)obj;
                _onCurrentTabChanged?.Invoke(tab);
            }));
        }

        public Tab(Action<Tab<T>> onCurrentTabChanged, string name, int id, T content)
        {
            _onCurrentTabChanged = onCurrentTabChanged;
            Name = name;
            Id = id;
            Content = content;
        }
    }

    public class TabVMBased : Tab<VMBase>
    {
        public TabVMBased(Action<Tab<VMBase>> onCurrentTabChanged, string name, int id, VMBase content) : base(onCurrentTabChanged, name, id, content)
        {

        }
    }

    public class MainMenuViewModel : VMBase
    {
        public ObservableCollection<TabVMBased> Tabs { get; } = new ObservableCollection<TabVMBased>();
        public INavigationStore NavigationStore { get; } = new NavigationStore();

        private Tab<VMBase> _selectedTabItem;

        public MainMenuViewModel() 
        {
            Tabs.Add(
                new TabVMBased(ChangedCurrentViewModel, "Профили навыков", 0, new SkillProfilesViewModel(ChangeCurrentPage))
            );
            Tabs.Add(
                new TabVMBased(ChangedCurrentViewModel, "Test навыков", 1, null)
            );

            Tabs[0].IsChecked = true;
            Tabs[1].IsEnable = false;
            NavigationStore.CurrentViewModel = Tabs[0].Content;
            _selectedTabItem = Tabs[0];
        }


        public void ChangeCurrentPage(VMBase viewmodel) 
        {
            _selectedTabItem.Content = viewmodel;
            NavigationStore.CurrentViewModel = viewmodel;
        }

        public void ChangedCurrentViewModel(Tab<VMBase> tab) 
        {
            _selectedTabItem = tab;
            NavigationStore.CurrentViewModel = tab.Content;
        }
    }
}
