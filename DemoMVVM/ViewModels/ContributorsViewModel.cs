using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SatsuiUi.Controls;
using SatsuiUi.Commands;
using System.Windows;

namespace DemoMVVM.ViewModels
{
    public class ContributorsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ContributorsListGroup> Groups { get; private set; }

        public ContributorsViewModel()
        {
            // Creating contributors group
            this.Groups = new ObservableCollection<ContributorsListGroup>();

            // My personal infos (heh !)
            ContributorsListGroup group = new ContributorsListGroup("Author");
            group.Items.Add(new ContributorsListItem("SatsuiBird",
                new ContributorsListLink(ContributorsListLinkType.Website, "http://messatsu-dojo.com/"),
                new ContributorsListLink(ContributorsListLinkType.Mail, "mailto:satsuibird@messatsu-dojo.com"),
                new ContributorsListLink(ContributorsListLinkType.Twitter, "https://twitter.com/MessatsuDojo"),
                new ContributorsListLink(ContributorsListLinkType.Facebook, "https://www.facebook.com/Messatsu-Dojo-637418412961990/"),
                new ContributorsListLink(ContributorsListLinkType.Youtube, "https://www.youtube.com/channel/UCxC_9W3gYfM_33ycLAMeRuQ"),
                new ContributorsListLink(ContributorsListLinkType.Steam, "http://steamcommunity.com/id/satsuibird"),
                new ContributorsListLink(ContributorsListLinkType.Twitter, "https://www.twitch.tv/satsuibird")
            ));
            this.Groups.Add(group);


            // My others projects, take a look !
            group = new ContributorsListGroup("Messatsu projects");
            group.Items.Add(new ContributorsListItem("SatsuiUi", "Set of controls and skins for WPF applications",
                new ContributorsListLink(ContributorsListLinkType.Website, "http://messatsu-dojo.com/"),
                new ContributorsListLink(ContributorsListLinkType.GitHub, "https://github.com/SatsuiBird/SatsuiUiDemo"),
                new ContributorsListLink(ContributorsListLinkType.Nuget, "https://www.nuget.org/packages/Messatsu.SatsuiUi/")
            ));
            group.Items.Add(new ContributorsListItem("SatsuiLocalization", "Easy localization of .NET applications", 
                new ContributorsListLink(ContributorsListLinkType.Website, "http://messatsu-dojo.com/"),
                new ContributorsListLink(ContributorsListLinkType.GitHub, "https://github.com/SatsuiBird/SatsuiLocalizationDemo"),
                new ContributorsListLink(ContributorsListLinkType.Nuget, "https://www.nuget.org/packages/Messatsu.SatsuiLocalization/")
            ));
            group.Items.Add(new ContributorsListItem("SatsuiMemory", "Read and edit easily applications memory", 
                new ContributorsListLink(ContributorsListLinkType.Website, "http://messatsu-dojo.com/"),
                new ContributorsListLink(ContributorsListLinkType.GitHub, "https://github.com/SatsuiBird/SatsuiMemoryDemo"),
                new ContributorsListLink(ContributorsListLinkType.Nuget, "https://www.nuget.org/packages/Messatsu.SatsuiMemory/")
            ));
            group.Items.Add(new ContributorsListItem("SatsuiOverlay", "Create customizable HTTP widgets", 
                new ContributorsListLink(ContributorsListLinkType.Website, "http://messatsu-dojo.com/"),
                new ContributorsListLink(ContributorsListLinkType.GitHub, "https://github.com/SatsuiBird/SatsuiOverlayDemo"),
                new ContributorsListLink(ContributorsListLinkType.Nuget, "https://www.nuget.org/packages/Messatsu.SatsuiOverlay/")
            ));
            this.Groups.Add(group);

            // Available default links
            group = new ContributorsListGroup("My group");
            group.Items.Add(new ContributorsListItem("Default links",
                new ContributorsListLink(""),
                new ContributorsListLink(ContributorsListLinkType.Mail, ""),
                new ContributorsListLink(ContributorsListLinkType.Website, ""),
                new ContributorsListLink(ContributorsListLinkType.Twitter, ""),
                new ContributorsListLink(ContributorsListLinkType.Facebook, ""),
                new ContributorsListLink(ContributorsListLinkType.Youtube, ""),
                new ContributorsListLink(ContributorsListLinkType.Twitch, ""),
                new ContributorsListLink(ContributorsListLinkType.SoundCloud, ""),
                new ContributorsListLink(ContributorsListLinkType.Steam, ""),
                new ContributorsListLink(ContributorsListLinkType.GitHub, ""),
                new ContributorsListLink(ContributorsListLinkType.Nuget, "")
            ));

            // Custom links
            group.Items.Add(new ContributorsListItem("Custom links",
                new ContributorsListLink("Link 1", "http://messatsu-dojo.com/", "/DemoMVVM;component/Resources/Images/x16-add.png"),
                new ContributorsListLink("Link 2", "mailto:satsuibird@messatsu-dojo.com", "/DemoMVVM;component/Resources/Images/x16-delete.png")
            ));

            // Links with ICommand
            group.Items.Add(new ContributorsListItem("Links with ICommand",
               new ContributorsListLink(ContributorsListLinkType.Twitch, "my twitch url", this.LinkClickedCommand),
               new ContributorsListLink("Custom Link", "my custom link url", "/DemoMVVM;component/Resources/Images/x16-right-arrow.png", this.LinkClickedCommand)

            ));

           this.Groups.Add(group);
        }


        #region Commands

        #region LinkClickedCommand

        private RelayCommand linkClickedCommand = null;
        public RelayCommand LinkClickedCommand
        {
            get
            {
                if (this.linkClickedCommand == null) this.linkClickedCommand = new RelayCommand(this.OnLinkClicked, this.CanLinkClicked);
                return this.linkClickedCommand;
            }
            set
            {
                if (value != this.linkClickedCommand)
                {
                    this.linkClickedCommand = value;
                    this.NotifyPropertyChanged("LinkClickedCommand");
                }
            }
        }

        public bool CanLinkClicked(object obj)
        {
            return true;
        }

        public void OnLinkClicked(object obj)
        {
            MessageBox.Show("Clicked : " + obj.ToString(), "DemoMVVM", MessageBoxButton.OK, MessageBoxImage.Information);
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
