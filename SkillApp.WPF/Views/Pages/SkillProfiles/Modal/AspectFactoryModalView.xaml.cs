using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace SkillApp.WPF.Views.Pages.SkillsProfile.Modal
{
    /// <summary>
    /// Логика взаимодействия для AspectFactoryModalView.xaml
    /// </summary>
    public partial class AspectFactoryModalView : UserControl
    {
        private static readonly Regex _regex = new Regex("[^0-9.-]+");

        public AspectFactoryModalView()
        {
            InitializeComponent();
        }

        private void ScoreStepTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }
    }
}
