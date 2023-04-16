using SkillApp.WPF.AppCore.Models;
using SkillApp.WPF.Controls.Modal;
using System.Windows.Input;
using SkillApp.WPF;
using SkillApp.WPF.AppModel;

namespace SkillApp.WPF.AppCore.ViewModels.Modal
{
    public class SkillFactoryViewModel : VMBase, IModalContentViewModel
    {
        #region Properties
     
        
        public SkillFactoryModel Model { get; }

        public double ContentWidth => 500;
        public double ContentHeight => 600;


        #endregion Properties


        #region Commands


        private RelayCommand _closeModalControlCommand;
        public ICommand CloseModalControlCommand
        {
            get => _closeModalControlCommand ??= new RelayCommand(obj => 
            {
                MainViewModel.ModalController.Close();
            });
        }

        private RelayCommand _actionCommand;
        public ICommand ActionCommand
        {
            get => _actionCommand ??= new RelayCommand(obj => 
            {
            
            });
        }

        private RelayCommand _hideModalControlCommand;
        public ICommand HideModalControlCommand
        {
            get => _hideModalControlCommand ??= new RelayCommand(obj => 
            {
                
            });
        }


        #endregion Commands


        #region Constructors


        public SkillFactoryViewModel()
        {
            Model = new SkillFactoryModel();
        }


        #endregion Constructors
    }
}
