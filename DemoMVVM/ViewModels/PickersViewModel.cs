using System;
using System.ComponentModel;
using System.Windows.Media;
using SatsuiUi.Commands;
using System.Windows;
using System.Windows.Input;

namespace DemoMVVM.ViewModels
{
    public class PickersViewModel : INotifyPropertyChanged
    {

        #region MyColor

        private Color myColor = Colors.Green;
        public Color MyColor
        {
            get { return this.myColor; }
            set
            {
                if(value != this.myColor)
                {
                    this.myColor = value;
                    this.NotifyPropertyChanged("MyColor");
                }
            }
        }

        #endregion


        #region MyImageFile

        private string myImageFile = "";
        public string MyImageFile
        {
            get { return this.myImageFile; }
            set
            {
                if (value != this.myImageFile)
                {
                    this.myImageFile = value;
                    this.NotifyPropertyChanged("MyImageFile");
                }
            }
        }

        #endregion

        #region MyImageOpacity

        private int myImageOpacity = 100;
        public int MyImageOpacity
        {
            get { return this.myImageOpacity; }
            set
            {
                if (value != this.myImageOpacity)
                {
                    this.myImageOpacity = value;
                    this.NotifyPropertyChanged("MyImageOpacity");
                }
            }
        }

        #endregion


        #region MySoundFile

        private string mySoundFile = "";
        public string MySoundFile
        {
            get { return this.mySoundFile; }
            set
            {
                if (value != this.mySoundFile)
                {
                    this.mySoundFile = value;
                    this.NotifyPropertyChanged("MySoundFile");
                }
            }
        }

        #endregion

        #region MySoundVolume

        private int mySoundVolume = 100;
        public int MySoundVolume
        {
            get { return this.mySoundVolume; }
            set
            {
                if (value != this.mySoundVolume)
                {
                    this.mySoundVolume = value;
                    this.NotifyPropertyChanged("MySoundVolume");
                }
            }
        }

        #endregion


        #region MyFontFamily

        private string myFontFamily = "Consolas";
        public string MyFontFamily
        {
            get { return this.myFontFamily; }
            set
            {
                if (value != this.myFontFamily)
                {
                    this.myFontFamily = value;
                    this.NotifyPropertyChanged("MyFontFamily");
                }
            }
        }

        #endregion

        #region MyFontSize

        private int myFontSize = 25;
        public int MyFontSize
        {
            get { return this.myFontSize; }
            set
            {
                if (value != this.myFontSize)
                {
                    this.myFontSize = value;
                    this.NotifyPropertyChanged("MyFontSize");
                }
            }
        }

        #endregion

        #region MyFontIsItalic

        private bool myFontIsItalic = false;
        public bool MyFontIsItalic
        {
            get { return this.myFontIsItalic; }
            set
            {
                if (value != this.myFontIsItalic)
                {
                    this.myFontIsItalic = value;
                    this.NotifyPropertyChanged("MyFontIsItalic");
                }
            }
        }

        #endregion

        #region MyFontIsBold

        private bool myFontIsBold = false;
        public bool MyFontIsBold
        {
            get { return this.myFontIsBold; }
            set
            {
                if (value != this.myFontIsBold)
                {
                    this.myFontIsBold = value;
                    this.NotifyPropertyChanged("MyFontIsBold");
                }
            }
        }

        #endregion

        #region MyFontIsUnderline

        private bool myFontIsUnderline = false;
        public bool MyFontIsUnderline
        {
            get { return this.myFontIsUnderline; }
            set
            {
                if (value != this.myFontIsUnderline)
                {
                    this.myFontIsUnderline = value;
                    this.NotifyPropertyChanged("MyFontIsUnderline");
                }
            }
        }

        #endregion


        #region MyKeyboardKey

        private Key myKeyboardKey = Key.None;
        public Key MyKeyboardKey
        {
            get { return this.myKeyboardKey; }
            set
            {
                if (value != this.myKeyboardKey)
                {
                    this.myKeyboardKey = value;
                    this.NotifyPropertyChanged("MyKeyboardKey");
                }
            }
        }

        #endregion


        public PickersViewModel()
        {

        }


        #region Commands

        #region ShowControlValueCommand

        private RelayCommand showControlValueCommand = null;
        public RelayCommand ShowControlValueCommand
        {
            get
            {
                if (this.showControlValueCommand == null) this.showControlValueCommand = new RelayCommand(this.OnShowControlValue);
                return this.showControlValueCommand;
            }
            set
            {
                if (value != this.showControlValueCommand)
                {
                    this.showControlValueCommand = value;
                    this.NotifyPropertyChanged("ShowControlValueCommand");
                }
            }
        }

        public void OnShowControlValue(object obj)
        {
            string id = obj.ToString();

            if(id == "color") MessageBox.Show("The selected color is : " + this.MyColor.ToString(), "DemoMVVM", MessageBoxButton.OK, MessageBoxImage.Information);
            else if(id == "image")
            {
                if (string.IsNullOrEmpty(this.MyImageFile)) MessageBox.Show("No image selected", "DemoMVVM", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                else MessageBox.Show("Image : " + this.MyImageFile + Environment.NewLine + "Opacity : " + this.MyImageOpacity, "DemoMVVM", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(id == "sound")
            {
                if (string.IsNullOrEmpty(this.MySoundFile)) MessageBox.Show("No sound selected", "DemoMVVM", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                else MessageBox.Show("Sound : " + this.MySoundFile + Environment.NewLine + "Volume : " + this.MySoundVolume, "DemoMVVM", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(id == "font")
            {
                if (string.IsNullOrEmpty(this.MyFontFamily)) MessageBox.Show("No font selected", "DemoMVVM", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                else MessageBox.Show(
                    "Font : " + this.MyFontFamily + Environment.NewLine + 
                    "Size : " + this.MyFontSize + Environment.NewLine +
                    "Italic : " + this.MyFontIsItalic + Environment.NewLine +
                    "Bold : " + this.MyFontIsBold + Environment.NewLine + 
                    "Italic : " + this.MyFontIsUnderline, "DemoMVVM", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(id == "key")
            {
                if(this.MyKeyboardKey == Key.None) MessageBox.Show("No key selected", "DemoMVVM", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                else MessageBox.Show("Key : " + this.MyKeyboardKey.ToString(), "DemoMVVM", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
