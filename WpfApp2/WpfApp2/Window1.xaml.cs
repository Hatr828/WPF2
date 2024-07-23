using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp2.Models;

namespace WpfApp2
{
    public partial class Window1 : Window
    {
        private Project project;
        private Taskk task;

        private ComboBox comboBox;
        private TextBox textblock_1;
        private TextBox textblock_2;

        private readonly Action updateCallback;

        public Window1(Project project, Action updateCallback)
        {
            InitializeComponent();
            this.project = project;
            this.updateCallback = updateCallback;
            InitializeUI_Project();
        }

        public Window1(Taskk task, Action updateCallback)
        {
            InitializeComponent();
            this.task = task;
            this.updateCallback = updateCallback;
            InitializeUI_Task();
        }

        private void InitializeUI_Project()
        {
            textblock_1 = new TextBox
            {
                FontSize = 24,
                Name = "textblock_1",
                Text = project?.Content,
                Height = 50
            };

            textblock_2 = new TextBox
            {
                FontSize = 24,
                Name = "textblock_2",
                Text = project?.description,
                Height = 50
            };

            Button button = new Button
            {
                FontSize = 24,
                Content = "Done"
            };
            button.Click += Button_Click;

            stack.Children.Add(textblock_1);
            stack.Children.Add(textblock_2);
            stack.Children.Add(button);
        }

        private void InitializeUI_Task()
        {
            textblock_1 = new TextBox
            {
                FontSize = 24,
                Name = "textblock_1",
                Text = task?.Content,
                Height = 50
            };

            textblock_2 = new TextBox
            {
                FontSize = 24,
                Name = "textblock_2",
                Text = task?.description,
                Height = 50
            };

            Button button = new Button
            {
                FontSize = 24,
                Content = "Done"
            };
            button.Click += Button_Click;

            comboBox = new ComboBox
            {
                 FontSize = 24 
            };
            comboBox.Items.Add("Low");
            comboBox.Items.Add("Middle");
            comboBox.Items.Add("High");

            stack.Children.Add(textblock_1);
            stack.Children.Add(textblock_2);
            stack.Children.Add(comboBox);
            stack.Children.Add(button);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (project != null)
            {
                project.Content = textblock_1.Text;
                project.description = textblock_2.Text;

                updateCallback?.Invoke();
                this.Close();
            }
            else if(task != null)
            {
                task.Content = textblock_1.Text;
                task.description = textblock_2.Text;
                task.priority = comboBox.SelectedItem?.ToString();

                updateCallback?.Invoke();
                this.Close();
            }
        }
    }
}
