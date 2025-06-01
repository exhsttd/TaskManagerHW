using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using TaskManagerHW.Classes;

namespace TaskManagerHW
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = DependencyResolver.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var scope = container.BeginLifetimeScope())
            {
                var form = scope.Resolve<TaskManager>();
                Application.Run(form);
            }
        }
    }
}
