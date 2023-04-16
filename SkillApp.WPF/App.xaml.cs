using System;
using System.Reflection;
using System.Windows;

namespace SkillApp.WPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;
        }

        //private static Assembly AssemblyResolve(object sender, ResolveEventArgs args)
        //{
        //    if (args.Name.Contains("ClassLibrary"))
        //    {
        //        return Assembly.Load(SkillApp.WPF.Properties.Resources.ClassLibrary1);
        //    }

        //    return null;
        //}
    }
}
