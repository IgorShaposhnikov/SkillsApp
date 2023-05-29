using SkillApp.WPF.Views.Windows;
using System;
using System.Reflection;
using System.Windows;

namespace SkillApp.WPF
{
    public class Runtime
    {
        private static App _app = new App();

        [STAThread]
        static void Main() 
        {
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;
            LoadDataTemplates();
            _app.Run(new LoadWindow());
        }

        public static void LoadDataTemplates()
        {
            _app.Resources.MergedDictionaries.Add(
                new ResourceDictionary() { Source = new Uri("pack://application:,,,/DataTemplates.xaml") });
        } 

        public static Assembly AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.Contains("SkillApp.Core"))
            {
                return Assembly.Load(Properties.Resources.SkillApp_Core);
            }
            if (args.Name.Contains("EPPlus"))
            {
                return Assembly.Load(Properties.Resources.EPPlus);
            }
            if (args.Name.Contains("EPPlus.Interfaces"))
            {
                return Assembly.Load(Properties.Resources.EPPlus_Interfaces);
            }
            if (args.Name.Contains("Microsoft.IO.RecyclableMemoryStream"))
            {
                return Assembly.Load(Properties.Resources.Microsoft_IO_RecyclableMemoryStream);
            }
            if (args.Name.Contains("EPPlus.System.Drawing"))
            {
                return Assembly.Load(Properties.Resources.EPPlus_System_Drawing);
            }
            if (args.Name.Contains("Xceed.Document.NET"))
            {
                return Assembly.Load(Properties.Resources.Xceed_Document_NET);
            }
            if (args.Name.Contains("Xceed.Words.NET"))
            {
                return Assembly.Load(Properties.Resources.Xceed_Words_NET);
            }

            return null;
        }
    }
}
