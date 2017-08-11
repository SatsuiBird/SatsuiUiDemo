using System.Windows;
using SatsuiUi.Skinning;
using DemoMVVM.ViewModels;
using DemoMVVM.Views;

namespace DemoMVVM
{
    public partial class Bootstrap
    {
        static public SkinManager SkinManager;

        protected override void OnStartup(StartupEventArgs e)
        {
            // Initializing SkinManager
            // Its set as a static member so i can access it everywhere and change the theme on the fly
            SkinManager = new SkinManager(Application.Current.Resources);


            #region (Optional) Add customs templates to extend existing skins

            // If you want to add your customs controls to existing skins,
            // you can use the method AddResource
            // I created a small custom template called MyCustomSeparator used in the view BasicsControlsView

            // My first resource dictionary contains the template
            SkinManager.AddResource(SkinManager.Skins[0], "/DemoMVVM;component/Theme/Crystal/MyCustomSeparator.xaml");

            // The two seconds directonaries contains colors used by the template
            SkinManager.AddResource(SkinManager.Skins[0], 1, "/DemoMVVM;component/Theme/Crystal/Light/MyCustomSeparator.xaml");
            SkinManager.AddResource(SkinManager.Skins[0], 2, "/DemoMVVM;component/Theme/Crystal/Dark/MyCustomSeparator.xaml");

            // I do the same for the skin Classic
            SkinManager.AddResource(SkinManager.Skins[1], "/DemoMVVM;component/Theme/Classic/MyCustomSeparator.xaml");
            SkinManager.AddResource(SkinManager.Skins[1], 1, "/DemoMVVM;component/Theme/Classic/White/MyCustomSeparator.xaml");
            SkinManager.AddResource(SkinManager.Skins[1], 2, "/DemoMVVM;component/Theme/Classic/Black/MyCustomSeparator.xaml");

            #endregion


            // Select the default skin
            // For now, there is 2 diffrents skins (Crystal / Classic) and 2 differents colors for each one
            SkinManager.SetCurrentSkin(SkinManager.Skins[0], 1);


            // Create and show the main view
            MainView view = new MainView() { DataContext = new MainViewModel() };
            view.ShowDialog();
        }


        protected override void OnExit(ExitEventArgs e)
        {
            // No resource need to be cleaned
            base.OnExit(e);
        }

    }
}
