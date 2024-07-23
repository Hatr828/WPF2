using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using WpfApp2.Models;

namespace WpfApp2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Goals goals;
        private Goal selectedGoal;
        private Taskk selectedTask;
        private ICollectionView goalsCollectionView;

        public ObservableCollection<Goal> GoalsCollection => goals.GoalsCollection;

        public Goal SelectedGoal
        {
            get => selectedGoal;
            set
            {
                if (selectedGoal != value)
                {
                    selectedGoal = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SelectedTasks));
                }
            }
        }

        public Taskk SelectedTask
        {
            get => selectedTask;
            set
            {
                if (selectedTask != value)
                {
                    selectedTask = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Taskk> SelectedTasks =>
            selectedGoal?.Tasks ?? new ObservableCollection<Taskk>();

        public ICommand AddProjectCommand { get; }
        public ICommand EditProjectCommand { get; }
        public ICommand DeleteProjectCommand { get; }
        public ICommand AddTaskCommand { get; }
        public ICommand EditTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }
        public ICommand ShowTrueProjectsCommand { get; }
        public ICommand ShowFalseProjectsCommand { get; }
        public ICommand ShowAllProjectsCommand { get; }

        public MainViewModel()
        {
            goals = new Goals();
            goalsCollectionView = CollectionViewSource.GetDefaultView(goals.GoalsCollection);

            AddProjectCommand = new RelayCommand(AddProject);
            EditProjectCommand = new RelayCommand(EditProject, CanEditOrDeleteProject);
            DeleteProjectCommand = new RelayCommand(DeleteProject, CanEditOrDeleteProject);
            AddTaskCommand = new RelayCommand(AddTask);
            EditTaskCommand = new RelayCommand(EditTask, CanEditOrDeleteTask);
            DeleteTaskCommand = new RelayCommand(DeleteTask, CanEditOrDeleteTask);
            ShowTrueProjectsCommand = new RelayCommand(ShowTrueProjects);
            ShowFalseProjectsCommand = new RelayCommand(ShowFalseProjects);
            ShowAllProjectsCommand = new RelayCommand(ShowAllProjects);
        }

        private void ShowTrueProjects()
        {
            goalsCollectionView.Filter = item =>
            {
                var goal = item as Goal;
                return goal != null && goal.Project.CheckBox.IsChecked == true;
            };
        }

        private void ShowFalseProjects()
        {
            goalsCollectionView.Filter = item =>
            {
                var goal = item as Goal;
                return goal != null && goal.Project.CheckBox.IsChecked == false;
            };
        }

        private void ShowAllProjects()
        {
            goalsCollectionView.Filter = null;
        }

        private void AddProject()
        {
            var newProject = new Project("New Project");
            var newGoal = new Goal(5, "New Goal")
            {
                Project = newProject
            };
            goals.GoalsCollection.Add(newGoal);
            SelectedGoal = newGoal;
        }

        private void EditProject()
        {
            if (SelectedGoal != null)
            {
                new Window1(SelectedGoal.Project, Update).ShowDialog();
            }
        }

        private void Update()
        {
            OnPropertyChanged(nameof(GoalsCollection));
            OnPropertyChanged(nameof(SelectedGoal));
            OnPropertyChanged(nameof(SelectedTasks));
        }

        private bool CanEditOrDeleteProject()
        {
            return SelectedGoal != null;
        }

        private void DeleteProject()
        {
            if (SelectedGoal != null)
            {
                goals.GoalsCollection.Remove(SelectedGoal);
                SelectedGoal = null;
                Update();
            }
        }

        private void AddTask()
        {
            if (SelectedGoal != null)
            {
                var newTask = new Taskk("New Task");
                SelectedGoal.Tasks.Add(newTask);
                OnPropertyChanged(nameof(SelectedTasks));
            }
        }

        private void EditTask()
        {
            if (SelectedGoal != null)
            {
                new Window1(SelectedTask, Update).ShowDialog();
            }
        }

        private bool CanEditOrDeleteTask()
        {
            return SelectedGoal != null && SelectedTasks.Any();
        }

        private void DeleteTask()
        {
            if (SelectedGoal != null && SelectedTasks.Any())
            {
                SelectedGoal.Tasks.Remove(SelectedTask);
                OnPropertyChanged(nameof(SelectedTasks));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
