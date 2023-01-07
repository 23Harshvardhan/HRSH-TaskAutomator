using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HRSH_TaskAutomator.Tools;
using HRSH_TaskAutomator.Windows;

namespace HRSH_TaskAutomator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void initializeDirectories()
        {
            if(!Directory.Exists(Paths.rootDir))
            {
                Directory.CreateDirectory(Paths.rootDir);
            }

            if(!Directory.Exists(Paths.tasksFolder))
            {
                Directory.CreateDirectory(Paths.tasksFolder);
            }

            if(!File.Exists(Paths.tasksFile))
            {
                FileStream fs = File.Create(Paths.tasksFile);
                fs.Dispose();
            }
        }

        void loadTasks()
        {
            string[] tasks = File.ReadAllLines(Paths.tasksFile);

            foreach(string task in tasks)
            {
                Button taskBtn = new Button();
                taskBtn.HorizontalAlignment = HorizontalAlignment.Stretch;
                taskBtn.Height = 32;
                taskBtn.Content = task;
                taskBtn.Margin = new Thickness(0,0,0,5);

                tasksPnl.Children.Add(taskBtn);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            initializeDirectories();
            loadTasks();
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            TaskBuilder tskBldr = new TaskBuilder();
            tskBldr.Owner = this;
            tskBldr.ShowDialog();
        }
    }
}
