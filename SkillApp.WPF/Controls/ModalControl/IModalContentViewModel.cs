using System.Windows.Input;

namespace SkillApp.WPF.Controls.Modal
{
    public interface IModalContentViewModel
    {
        public abstract ICommand CloseModalControlCommand { get; }
        public abstract ICommand ActionCommand { get; }
        public abstract ICommand HideModalControlCommand { get; }
        public abstract double ContentWidth { get; }
        public abstract double ContentHeight { get; }
    }
}
