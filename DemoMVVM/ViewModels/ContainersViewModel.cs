using System;
using System.ComponentModel;
using SatsuiUi.Commands;

namespace DemoMVVM.ViewModels
{
    public class ContainersViewModel : INotifyPropertyChanged
    {

        #region CustomHeaderResult

        private string customHeaderResult = "No button clicked..";
        public string CustomHeaderResult
        {
            get { return this.customHeaderResult; }
            set
            {
                if (value != this.customHeaderResult)
                {
                    this.customHeaderResult = value;
                    this.NotifyPropertyChanged("CustomHeaderResult");
                }
            }
        }

        #endregion


        public ContainersViewModel()
        {

        }


        #region Commands

        #region CustomHeaderCommand

        private RelayCommand customHeaderCommand = null;
        public RelayCommand CustomHeaderCommand
        {
            get
            {
                if (this.customHeaderCommand == null) this.customHeaderCommand = new RelayCommand(this.OnCustomHeader);
                return this.customHeaderCommand;
            }
            set
            {
                if (value != this.customHeaderCommand)
                {
                    this.customHeaderCommand = value;
                    this.NotifyPropertyChanged("CustomHeaderCommand");
                }
            }
        }


        public void OnCustomHeader(object obj)
        {
            string id = obj.ToString();
            this.CustomHeaderResult = "Button " + id + " clicked !";
            
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
