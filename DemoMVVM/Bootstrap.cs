using System.Windows;
using System.Diagnostics;

namespace DemoMVVM
{
    public partial class Bootstrap
    {

        protected override void OnStartup(StartupEventArgs e)
        {

            Debug.WriteLine("OnStartup()");
        }


        protected override void OnExit(ExitEventArgs e)
        {
            Debug.WriteLine("OnExist()");

            base.OnExit(e);
        }

    }
}
