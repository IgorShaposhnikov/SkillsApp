using SkillApp.WPF.Controls.Modal;
using SkillApp.WPF.AppModel;

namespace SkillApp.WPF.AppCore.ViewModels.Modal
{
    public sealed class ModalController : VMBase, IModalController
    {
        private bool _isOpen;
        public bool IsOpen 
        {
            get => _isOpen; set 
            {
                _isOpen = value;
                OnPropertyChanged();
            }
        } 

        public IModalContentViewModel CurrentModalContent { get; private set; }


        public void Close()
        {
            IsOpen = false;
            ChangeCurrentModalContent(null);
        }

        public void Open(IModalContentViewModel modalViewModel)
        {
            IsOpen = true;
            ChangeCurrentModalContent(modalViewModel);
        }

        private void ChangeCurrentModalContent(IModalContentViewModel viewModel) 
        {
            CurrentModalContent = viewModel;
            OnPropertyChanged(nameof(CurrentModalContent));
        }
    }
}
