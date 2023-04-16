using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SkillApp.WPF.AppModel
{
    public interface IViewModel : INotifyPropertyChanged, IDisposable
    {
        abstract void OnPropertyChanged([CallerMemberName] string prop = "");
    }

    public abstract class VMBase : IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public virtual void Dispose() { }
    }
}
