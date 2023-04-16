namespace SkillApp.WPF.Controls.Modal
{
    public interface IModalController
    {
        public bool IsOpen { get; }
        public IModalContentViewModel CurrentModalContent { get; }


        public void Open(IModalContentViewModel modalViewModel);
        public void Close();
    }
}
