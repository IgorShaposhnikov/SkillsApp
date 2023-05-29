using SkillApp.WPF.Base.Modal;
using System;

namespace SkillApp.WPF.ViewModels.Modal
{
    public class ModalDialogWindowViewModel : ModalViewModelBase
    {
        private readonly Action _okAction;
        private readonly Action _cancelAction;


        #region Properties


        public string Title { get; }
        public string Description { get; }
        public bool IsImportant { get; }


        #endregion Properties



        #region Constructors


        public ModalDialogWindowViewModel(Action okAction, Action cancelAction, string header, string description, bool isImportant = false)
        {
            _okAction = okAction;
            _cancelAction = cancelAction;

            Title = header;
            Description = description;
            IsImportant = isImportant;

            ActionCommandAction += OKAction;
            CloseCommandAction += CancelAction;
        }


        #endregion Constructors


        #region Private Methods


        private void OKAction(object parameters) 
        {
            _okAction();
        }

        private void CancelAction() 
        {
            _cancelAction();
        }


        #endregion Private Methods
    }
}
