namespace SkillApp.WPF.Base.Store
{
    public delegate void CurrentViewModelChangedEventHandler();

    public interface INavigationStore
    {
        /// <summary>
        /// ViewModel выбранной страницы
        /// </summary>
        VMBase CurrentViewModel { get; set; }
        /// <summary>
        /// Событие срабатывающие при изменении CurrentViewModel
        /// </summary>
        event CurrentViewModelChangedEventHandler CurrentViewModelChanged;
    }
}
