using System.Collections.ObjectModel;

namespace WpfApp2.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Project Project { get; set; }
        public ObservableCollection<Taskk> Tasks { get; set; }

        public Goal(int id, string name)
        {
            Id = id;
            Name = name;
            Tasks = new ObservableCollection<Taskk>();
        }

        public ObservableCollection<Taskk> GetAllTasks()
        {
            return new ObservableCollection<Taskk>(Tasks);
        }
    }
}
