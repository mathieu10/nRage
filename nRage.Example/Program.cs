using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;

namespace nRage.Example {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            
            InitialiseIOC();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        private static void InitialiseIOC() { 
            var _ioc = new StandardKernel();
            _ioc.Bind<IRetriever>().To<WebRetriever>();
        }
    }
}
