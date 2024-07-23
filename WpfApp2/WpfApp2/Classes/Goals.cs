using System.Collections.ObjectModel;

namespace WpfApp2.Models
{
    public class Goals
    {
        public ObservableCollection<Goal> GoalsCollection { get; set; }

        public Goals()
        {
            GoalsCollection = new ObservableCollection<Goal>();
        }

        public ObservableCollection<Goal> GetAllGoals()
        {
            return new ObservableCollection<Goal>(GoalsCollection);
        }
    }
}
