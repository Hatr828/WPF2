using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp2.Models;
using WpfApp2.ViewModels;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void ListBox_Projects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedGoal = (Goal)ListBox_Projects.SelectedItem;
            var viewModel = (MainViewModel)DataContext;
            viewModel.SelectedGoal = selectedGoal;
        }

        private void ListView_Tasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTask = (Taskk)ListView_Tasks.SelectedItem;
            var viewModel = (MainViewModel)DataContext;
            viewModel.SelectedTask = selectedTask;
        }
    }
}
