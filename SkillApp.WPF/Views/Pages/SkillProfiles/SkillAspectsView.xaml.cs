using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SkillApp.WPF.Views.Pages.SkillsProfile
{
    /// <summary>
    /// Логика взаимодействия для SkillAspectsView.xaml
    /// </summary>
    public partial class SkillAspectsView : UserControl
    {
        public SkillAspectsView()
        {
            InitializeComponent();
            
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    row.DetailsVisibility = row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    break;
                }
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    row.DetailsVisibility = row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    break;
                }
        }

        private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //TODO: in the future
            //MessageBox.Show(sender.GetType().ToString());
            //var row = (DataGridRow)sender;
            //for (var i = 0; i < VisualTreeHelper.GetChildrenCount(sender as Visual); i++)
            //    Console.WriteLine(i);
            //    //if (vis is Expander)
            //    //{
            //    //    var row = (Expander)vis;
            //    //    row.IsExpanded = !row.IsExpanded;
            //    //    break;
            //    //}
        }
    }
}
