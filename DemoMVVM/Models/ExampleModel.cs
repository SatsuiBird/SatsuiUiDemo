using System.Windows.Controls;

namespace DemoMVVM.Models
{
    public class ExampleModel
    {
        public string Title { get; private set; }
        public UserControl Content { get; private set; }

        public ExampleModel(string title, UserControl content)
        {
            this.Title = title;
            this.Content = content;
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
