using SkillApp.WPF.ViewModels;
using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace SkillApp.WPF.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window
    {
        private readonly MainViewModel _mainViewModel;

        public LoadWindow()
        {
            InitializeComponent();
            _mainViewModel = App.Current.Resources["MainVM"] as MainViewModel;
        }


        #region Public Methods


        #endregion Public Methods


        #region Private Methods


        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            ChangeCurrentToMainWindow();
        }

        private void LoadProject_Click(object sender, RoutedEventArgs e)
        {
            var defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\SkillAppSaves";
            var dirInfo = new DirectoryInfo(defaultPath);
            if (!dirInfo.Exists) 
            {
                defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = defaultPath;
                openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;


                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var projectPath = openFileDialog.FileName;
                    if (string.IsNullOrEmpty(projectPath)) 
                    {
                        return;
                    }

                    if (projectPath.Contains(".xml")) 
                    { 
                        _mainViewModel.LoadXmlProject(projectPath);
                    }

                    if (projectPath.Contains(".xlsx"))
                    {
                        _mainViewModel.LoadExcelProject(projectPath);
                    }
                    ChangeCurrentToMainWindow();
                }
            }
        }

        private void ChangeCurrentToMainWindow()
        {
            App.Current.MainWindow = new MainWindow();
            this.Close();
            App.Current.MainWindow.Show();
        }


        #endregion Private Methods
    }
}
