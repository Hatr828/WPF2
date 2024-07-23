using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Timers;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        private Project selectedProject;
        private Task selectedTask;
        private int currentPage;
        private const int PageSize = 5;

        public ObservableCollection<Project> Projects { get; set; }
        public ObservableCollection<Project> PagedProjects => new ObservableCollection<Project>(Projects.Skip(currentPage * PageSize).Take(PageSize));
        public ObservableCollection<Task> Tasks => selectedProject?.Tasks;

        public Project SelectedProject
        {
            get => selectedProject;
            set
            {
                selectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
                OnPropertyChanged(nameof(Tasks));
            }
        }

        public Task SelectedTask
        {
            get => selectedTask;
            set
            {
                selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }

        public ICommand AddProjectCommand { get; }
        public ICommand EditProjectCommand { get; }
        public ICommand DeleteProjectCommand { get; }
        public ICommand AddTaskCommand { get; }
        public ICommand EditTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand PreviousPageCommand { get; }
        public ICommand FilterTasksCommand { get; }

        public MainViewModel()
        {
            Projects = new ObservableCollection<Project>();
            AddProjectCommand = new RelayCommand(AddProject);
            EditProjectCommand = new RelayCommand(EditProject, () => SelectedProject != null);
            DeleteProjectCommand = new RelayCommand(DeleteProject, () => SelectedProject != null);
            AddTaskCommand = new RelayCommand(AddTask, () => SelectedProject != null);
            EditTaskCommand = new RelayCommand(EditTask, () => SelectedTask != null);
            DeleteTaskCommand = new RelayCommand(DeleteTask, () => SelectedTask != null);
            NextPageCommand = new RelayCommand(NextPage, () => (currentPage + 1) * PageSize < Projects.Count);
            PreviousPageCommand = new RelayCommand(PreviousPage, () => currentPage > 0);
            FilterTasksCommand = new RelayCommand<string>(FilterTasks);
        }

        private void AddProject() { /* Реализация добавления проекта */ }
        private void EditProject() { /* Реализация редактирования проекта */ }
        private void DeleteProject() { /* Реализация удаления проекта */ }
        private void AddTask() { /* Реализация добавления задачи */ }
        private void EditTask() { /* Реализация редактирования задачи */ }
        private void DeleteTask() { /* Реализация удаления задачи */ }
        private void NextPage() { currentPage++; OnPropertyChanged(nameof(PagedProjects)); }
        private void PreviousPage() { currentPage--; OnPropertyChanged(nameof(PagedProjects)); }
        private void FilterTasks(string filter) { /* Реализация фильтрации задач */ }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }


    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ObservableCollection<Task> Tasks { get; set; } = new ObservableCollection<Task>();
    }

    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => canExecute == null || canExecute();

        public void Execute(object parameter) => execute();

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => canExecute == null || canExecute((T)parameter);

        public void Execute(object parameter) => execute((T)parameter);

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

}