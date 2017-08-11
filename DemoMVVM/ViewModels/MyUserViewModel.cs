using System;
using System.ComponentModel;

namespace DemoMVVM.ViewModels
{
    public class MyUserViewModel : INotifyPropertyChanged
    {
        static private int newUserId = 0;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Mail { get; private set; }

        #region Available

        private bool available = false;
        public bool Available
        {
            get { return this.available; }
            set
            {
                if (value != this.available)
                {
                    this.available = value;
                    this.NotifyPropertyChanged("Available");
                }
            }
        }

        #endregion

        public MyUserViewModel(string name, string mail, bool available)
        {
            this.Id = ++newUserId;
            this.Name = name;
            this.Mail = mail;
            this.Available = available;
        }

        public MyUserViewModel()
        {
            this.Id = ++newUserId;
            this.Name = GetRandomString();
            this.Mail = this.Name + "@messatsu-dojo.com";
            this.Available = false;
        }


        #region ToString

        public override string ToString()
        {
            return this.Name;
        }

        #endregion


        #region GetRandomString

        public static string GetRandomString()
        {
            string path = System.IO.Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path;
        }

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
