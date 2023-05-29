using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace SkillApp.WPF.Views.Pages.SkillsProfile.Modal
{
    /// <summary>
    /// Логика взаимодействия для AspectEditModalView.xaml
    /// </summary>
    public partial class AspectEditModalView : UserControl
    {
        private static readonly Regex _regex = new Regex("[^0-9.]");

        public AspectEditModalView()
        {
            InitializeComponent();
        }

        private void ScoreStepTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }
    }
}
