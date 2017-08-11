using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SatsuiUi.Controls;
using SatsuiUi.Commands;
using DemoMVVM.Models;
using DemoMVVM.Views;
using DemoMVVM.ViewModels;
using System.Windows.Controls;

namespace DemoMVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        #region SkinItems

        private ObservableCollection<SkinComboBoxItem> skinItems;
        public ObservableCollection<SkinComboBoxItem> SkinItems
        {
            get { return this.skinItems; }
            set
            {
                if (value != this.skinItems)
                {
                    this.skinItems = value;
                    this.NotifyPropertyChanged("SkinItems");
                }
            }
        }

        #endregion

        #region SelectedSkin

        private SkinComboBoxItem selectedSkin = null;
        public SkinComboBoxItem SelectedSkin
        {
            get { return this.selectedSkin; }
            set
            {
                if (value != this.selectedSkin)
                {
                    this.selectedSkin = value;
                    this.NotifyPropertyChanged("SelectedSkin");
                }
            }
        }

        #endregion

        #region ExamplesItems

        private ObservableCollection<ExampleModel> exampleItems;
        public ObservableCollection<ExampleModel> ExampleItems
        {
            get { return this.exampleItems; }
            set
            {
                if (value != this.exampleItems)
                {
                    this.exampleItems = value;
                    this.NotifyPropertyChanged("ExampleItems");
                }
            }
        }

        #endregion

        #region SelectedExample

        private ExampleModel selectedExample = null;
        public ExampleModel SelectedExample
        {
            get { return this.selectedExample; }
            set
            {
                if (value != this.selectedExample)
                {
                    this.selectedExample = value;
                    this.NotifyPropertyChanged("SelectedExample");
                    this.NotifyPropertyChanged("ExampleTitle");
                    this.NotifyPropertyChanged("ExampleContent");
                }
            }
        }

        #endregion

        #region ExampleTitle

        public string ExampleTitle
        {
            get
            {
                if (this.SelectedExample != null) return this.SelectedExample.Title;
                else return "No example selected";
            }
        }

        #endregion

        #region ExampleContent

        public UserControl ExampleContent
        {
            get
            {
                if (this.SelectedExample != null) return this.SelectedExample.Content;
                else return null;
            }
        }

        #endregion 

        public MainViewModel()
        {

            // Loading available skins
            this.SkinItems = new ObservableCollection<SkinComboBoxItem>();
            this.SkinItems.Add(new SkinComboBoxItem(Bootstrap.SkinManager.Skins[0], 1, "Crystal - Light"));
            this.SkinItems.Add(new SkinComboBoxItem(Bootstrap.SkinManager.Skins[0], 2, "Crystal - Dark"));
            this.SkinItems.Add(new SkinComboBoxItem(Bootstrap.SkinManager.Skins[1], 1, "Classic - White"));
            this.SkinItems.Add(new SkinComboBoxItem(Bootstrap.SkinManager.Skins[1], 2, "Classic - Black"));

            // Default selected skin
            this.SelectedSkin = this.SkinItems[0];

            // Loading examples
            this.ExampleItems = new ObservableCollection<ExampleModel>();
            this.ExampleItems.Add(new ExampleModel("Basics controls", new BasicsControlsView()));
            this.ExampleItems.Add(new ExampleModel("Pickers controls", new PickersView() { DataContext = new PickersViewModel() }));
            this.ExampleItems.Add(new ExampleModel("Lists controls", new ListsView() { DataContext = new ListsViewModel() }));
            this.ExampleItems.Add(new ExampleModel("Containers controls", new ContainersView() { DataContext = new ContainersViewModel() }));
            this.ExampleItems.Add(new ExampleModel("ContributorsList control", new ContributorsView() { DataContext = new ContributorsViewModel() }));
            this.SelectedExample = this.ExampleItems[0];
        }


        #region Commands


        #region UpdateSkinCommand

        private RelayCommand updateSkinCommand = null;
        public RelayCommand UpdateSkinCommand
        {
            get
            {
                if (this.updateSkinCommand == null) this.updateSkinCommand = new RelayCommand(this.OnUpdateSkin);
                return this.updateSkinCommand;
            }
            set
            {
                if (value != this.updateSkinCommand)
                {
                    this.updateSkinCommand = value;
                    this.NotifyPropertyChanged("UpdateSkinCommand");
                }
            }
        }

        public void OnUpdateSkin(object obj)
        {
            Bootstrap.SkinManager.SetCurrentSkin(this.SelectedSkin.Skin, this.SelectedSkin.Color);
        }


        #endregion


        #endregion


        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        #endregion
    }
}
