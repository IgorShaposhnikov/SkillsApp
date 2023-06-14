using SkillApp.Core.Printouts;
using SkillApp.WPF.Base.Commands;
using SkillApp.WPF.Base.Modal;
using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;

namespace SkillApp.WPF.ViewModels.SkillsProfile.Modal
{
    public class SaveSkillsProfileMenuViewModel : ModalViewModelBase
    {
        #region ModalViewModelBase


        public override double Height => base.Height;
        public override double Width => base.Width;


        #endregion ModalViewModelBase


        private readonly Core.Models.SkillsProfile _skillsProfile;


        #region Properties


        private string _profileName;
        public string ProfileName
        {
            get => _profileName; set
            {
                _profileName = value;
                OnPropertyChanged();
            }
        }


        private string _savesDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\SkillAppSaves";
        public string SavesDirectoryPath
        {
            get => _savesDirectoryPath; set
            {
                _savesDirectoryPath = value;
                OnPropertyChanged();
            }
        }


        private bool _isXmlExport = true;
        public bool IsXmlExport
        {
            get => _isXmlExport; set
            {
                _isXmlExport = value;
                OnPropertyChanged();
            }
        }

        private bool _isXlsxExport = true;
        public bool IsXlsxExport
        {
            get => _isXlsxExport; set
            {
                _isXlsxExport = value;
                OnPropertyChanged();
            }
        }

        private bool _isAllFilesNotSelected;
        public bool IsAllFilesNotSelected 
        {
            get => _isAllFilesNotSelected; set 
            {
                _isAllFilesNotSelected = value;
                OnPropertyChanged();
            }
        }


        #endregion Properties


        #region Commands


        private RelayCommand _openFolderDialogBrowser;
        public ICommand OpenFolderDialogBrowser 
        {
            get => _openFolderDialogBrowser ?? (_openFolderDialogBrowser = new RelayCommand(obj => 
            {
                OpenFolderBrowserDialog();
            }));
        }


        #endregion Commands


        #region Constructors


        public SaveSkillsProfileMenuViewModel(Core.Models.SkillsProfile skillsProfile)
        {
            ActionCommandAction += Save;

            _skillsProfile = skillsProfile;
            ProfileName = skillsProfile.Name;
            SavesDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\SkillAppSaves";
        }


        #endregion Constructors



        #region Private Methods


        private void Save(object parameters) 
        {
            IsCloseWhenActionCommandExecuted = true;
            CheckAndCreateDirectory(SavesDirectoryPath);

            if (IsXmlExport) 
            {
                XMLPrintout.SaveSkillProfile(_skillsProfile, SavesDirectoryPath);
            }
            
            if (IsXlsxExport) 
            {
                Console.WriteLine(SavesDirectoryPath);
                try
                {
                    ExcelPrintout.SaveSkillProfile(_skillsProfile, SavesDirectoryPath);
                }
                catch 
                {
                    IsCloseWhenActionCommandExecuted = false;
                }
            }
        }

        private void OpenFolderBrowserDialog()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Выберите папку для сохранения профиля";
                dialog.SelectedPath = SavesDirectoryPath;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SavesDirectoryPath = dialog.SelectedPath;
                }
            }
        }


        /// <summary>
        /// Проверяет существования пути, если папки не существует создаст её.
        /// </summary>
        private static void CheckAndCreateDirectory(string path) 
        {
            DirectoryInfo savesDirInfo = new DirectoryInfo(path);
            if (!savesDirInfo.Exists)
            {
                savesDirInfo.Create();
            }
        }

        #endregion Private Methods
    }
}
