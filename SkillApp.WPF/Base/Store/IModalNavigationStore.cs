using SkillApp.WPF.Base.Modal;

namespace SkillApp.WPF.Base.Store
{
    public interface IModalNavigationStore
    {
        /// <summary>
        /// ViewModel активного окна
        /// </summary>
        IModalViewModel CurrentViewModel { get; }
        /// <summary>
        /// Отвечает на вопрос является ли модальное окно открытым.
        /// </summary>
        bool IsOpen { get; }
        /// <summary>
        /// Открывает модальное окно (в качестве агрумента принимает IModalViewModel)
        /// </summary>
        void Open(IModalViewModel viewModel);
        /// <summary>
        /// Закрывает модальное окно (с удаление ссылки на viewmodel).
        /// </summary>
        void Close();
        /// <summary>
        /// Закрывает модальное окно (с сохранение ссылки на viewmodel).
        /// </summary>
        void Hide();
    }
}
