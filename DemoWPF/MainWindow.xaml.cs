using System.Windows;
using System.Windows.Controls;
using SatsuiUi.Skinning;
using SatsuiUi.Controls;

namespace DemoWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SatsuiWindow
    {
        private SkinManager manager;

        public MainWindow()
        {
            InitializeComponent();

            // Creating the SkinManager
            this.manager = new SkinManager(Application.Current.Resources);

            // Loading availables skins into the combobox
            this.cmbSkins.Items.Add("Crystal - Light");
            this.cmbSkins.Items.Add("Crystal - Dark");
            this.cmbSkins.Items.Add("Classic - White");
            this.cmbSkins.Items.Add("Classic - Black");

            // Selecting default skin skin
            this.cmbSkins.SelectedIndex = 0;
        }

        private void SelectSkin(int index)
        {
            switch(index)
            {
                case 0: // Crystal - Light
                    this.manager.SetCurrentSkin(this.manager.Skins[0], 1);
                    break;

                case 1: // Crystal - Dark
                    this.manager.SetCurrentSkin(this.manager.Skins[0], 2);
                    break;

                case 2: // Classic - White
                    this.manager.SetCurrentSkin(this.manager.Skins[1], 1);
                    break;

                case 3: // Classic - Black
                    this.manager.SetCurrentSkin(this.manager.Skins[1], 2);
                    break;
            }
        }

        #region Controls events

        private void cmbSkins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectSkin(this.cmbSkins.SelectedIndex);
        }

        private void btnShowInput_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtInput.Text)) MessageBox.Show("No text entered !", "DemoWPF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else MessageBox.Show("Text : " + this.txtInput.Text, "DemoWPF", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion

    }
}
