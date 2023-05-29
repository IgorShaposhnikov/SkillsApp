using System.Windows.Input;

namespace SkillApp.WPF.Base.Modal
{
    public interface IModalViewModel
    {
        /// <summary>
        /// Устанавливает ширину модального окна.
        /// </summary>
        double Width { get; }
        /// <summary>
        /// Устанавливает высоту модального окна.
        /// </summary>
        double Height { get; }
        /// <summary>
        /// Команда на закрытие модального окна.
        /// </summary>
        ICommand CloseCommand { get; }
        /// <summary>
        /// Действие которые должно выполниться, например экспорт, создание сборки и n
        /// </summary>
        ICommand ActionCommand { get; }
    }
}
