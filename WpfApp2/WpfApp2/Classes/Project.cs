using System.ComponentModel;
using System.Windows.Controls;

namespace WpfApp2.Models
{
    public class Project : INotifyPropertyChanged
    {
        private string content;

        public string description;
        public CheckBox CheckBox { get; }

        public string Content
        {
            get => content;
            set
            {
                if (content != value)
                {
                    content = value;
                    OnPropertyChanged();
                }
            }
        }

        public Project(string content, string description = "")
        {
            this.content = content;
            this.description = description;
            this.CheckBox = new CheckBox { Content = content };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
