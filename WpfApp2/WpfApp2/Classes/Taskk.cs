using System.ComponentModel;
using System.Windows.Controls;

namespace WpfApp2.Models
{
    public class Taskk : INotifyPropertyChanged
    {
        private string content;
        public CheckBox CheckBox { get; }

        public string priority;

        public string description;

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

        public Taskk(string content)
        {
            this.content = content;
            this.CheckBox = new CheckBox { Content = content };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
