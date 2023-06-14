using SkillApp.WPF.Base.Commands;
using SkillApp.WPF.Base.Store;
using System;
using System.Windows.Input;

namespace SkillApp.WPF.Base.Modal
{
    public abstract class ModalViewModelBase : VMBase, IModalViewModel
    {
        protected const double DefaultWidth = 360;
        protected const double DefaultHeight = 420;

        public virtual double Width => DefaultWidth + 200;
        public virtual double Height => DefaultHeight + 200;

        public bool IsCloseWhenActionCommandExecuted { get; set; } = true;

        /// <summary>
        /// Делегат который выполниться после вызова CloseCommand
        /// </summary>
        public Action CloseCommandAction;

        private RelayCommand _closeCommand;
        public ICommand CloseCommand 
        {
            get => _closeCommand ?? (_closeCommand = new RelayCommand(obj => 
            {
                ModalNavigationStore.Instance.Close();
                CloseCommandAction?.Invoke();
            }));
        }

        /// <summary>
        /// Делегат который выполниться после вызова ActionCommand
        /// </summary>
        public Action<object> ActionCommandAction;

        private RelayCommand _actionCommand;
        public ICommand ActionCommand
        {
            get => _actionCommand ?? (_actionCommand = new RelayCommand(obj =>
            {
                ActionCommandAction?.Invoke(obj);
                if (IsCloseWhenActionCommandExecuted)
                {
                    ModalNavigationStore.Instance.Close();
                }
            }));
        }

        public virtual ICommand HideCommand { get; }
    }
}
