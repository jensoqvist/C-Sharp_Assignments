
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Input;
using System.Windows.Threading;
using ToDoReminder.Data;
using ToDoReminder.ViewModels;
using ToDoReminder.Wins;

namespace ToDoReminder
{
    /// <summary>
    /// Main ViewModel
    /// </summary>
    public class MainViewModel :BaseViewModel
    {
        /// <summary>
        /// ViewModels for diffrent views
        /// </summary>
        #region ViewModels
        private BaseViewModel currentViewModel;
        private TaskViewModel taskViewModel = new();
        private AboutViewModel aboutView = new();
        private MenuViewModel menuViewModel = new();



        public BaseViewModel CurrentView { get => currentViewModel; set { currentViewModel = value; OnPropertyChanged(); } }
        /// <summary>
        /// Viewmodel handling adding/editing of tasks
        /// </summary>
        public TaskViewModel TaskView {get => taskViewModel; set { taskViewModel = value; OnPropertyChanged(); } }     

        /// <summary>
        /// ViewModel handling Menu
        /// </summary>
        public MenuViewModel Menu { get => menuViewModel; set { menuViewModel = value; OnPropertyChanged(); } }
        #endregion

        #region fields
        private string now = DateTime.Now.ToString("HH:mm:ss");
        private TaskManager taskManager = new TaskManager();
        private ObservableCollection<TaskToDo> tasks;
        private TaskToDo selectedTask;
        private int selectedIndex;
        private bool enableEdit = false;
        #endregion

        #region propertys   
        public SecondaryWin SecondaryWin { get; set; }
        public ObservableCollection<TaskToDo> Tasks { get { return tasks; } set { tasks = value; taskManager.TasksToDo = new List<TaskToDo> (value); OnPropertyChanged(); } }
        public TaskToDo SelectedTask { get { return selectedTask; } set { selectedTask = value; if (value != null) EnableEdit = true; else EnableEdit = false; OnPropertyChanged(); } }
        public int SelectedIndex { get { return selectedIndex; } set { selectedIndex = value;  OnPropertyChanged(); } }
        public bool EnableEdit { get { return enableEdit; } set { enableEdit = value; OnPropertyChanged(); } }

        public string Now { get => DateTime.Now.ToString("HH:mm:ss"); } 
        #endregion

        #region Commands
        public ICommand SaveList { get; set; }
        public ICommand NewTask { get; set; }
        public ICommand EditTask { get; set; }
        public ICommand SaveTask { get; set; }
        public ICommand About { get; set; }

        public ICommand Delete { get; set; }

        #endregion


        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainViewModel()
        {
            _ = UpdateNow();
            Tasks = new ObservableCollection<TaskToDo>(taskManager.TasksToDo);
            NewTask = new RelayCommand(NewTaskCommand);
            EditTask = new RelayCommand(EditTaskCommand);
            SaveTask = new RelayCommand(SaveTaskMethod);
            SaveList = new RelayCommand(SaveCommand);
            Delete = new RelayCommand(DeleteMethod);
            About = new RelayCommand(AboutCommand);

            CheckSaved();

        }
        #endregion

        #region Methods
        /// <summary>
        /// Cheks if saved list exists and if so loads it
        /// </summary>
        public void CheckSaved()
        {
            FileHandler fileHandler = new FileHandler();
            if (fileHandler.CheckExists())
            {
                Tasks = new ObservableCollection<TaskToDo>(fileHandler.BinaryReader().TasksToDo);
            }
        }

        public void SaveCommand()
        {
            new FileHandler().BinaryFileWriter(taskManager);
        }

        /// <summary>
        /// Opens secondary window
        /// </summary>
        public void OpenSecodaryView()
        {
            if (Application.Current.Windows.OfType<SecondaryWin>().FirstOrDefault() == null)
            {
                SecondaryWin = new();
                SecondaryWin.DataContext = this;
                SecondaryWin.Show();
            }
        }

        /// <summary>
        /// Closes secondary
        /// </summary>
        public void CloseSecondary()
        {
            SecondaryWin?.Close();
        }

        /// <summary>
        /// Opens secondary win to add new task
        /// </summary>
        public void NewTaskCommand()
        {
            CurrentView = TaskView;
            TaskView.CurTask = new TaskToDo();
            TaskView.Title = "New Task";
            TaskView.NewTask = true;
            OpenSecodaryView();
        }

        /// <summary>
        /// open win to edit selected task
        /// </summary>
        public void EditTaskCommand()
        {
            CurrentView = TaskView;
            TaskView.CurTask = new TaskToDo() 
            {
                Date =  SelectedTask.Date,
                Hour = SelectedTask.Hour,
                Minute = SelectedTask.Minute,
                Priority = SelectedTask.Priority,
                Description = SelectedTask.Description,
            };
            TaskView.Title = "Edit Task";
            TaskView.NewTask = false;
            OpenSecodaryView();
        }

        /// <summary>
        /// Deletes task at given index
        /// </summary>
        private void DeleteMethod()
        {
            Tasks.RemoveAt(SelectedIndex);
        }

        /// <summary>
        /// method  that saves task to list
        /// </summary>
        private void SaveTaskMethod()
        {
            if (CheckValid())
            {
                if (TaskView.NewTask)
                    Tasks.Add(TaskView.CurTask);
                     
                else
                    Tasks[SelectedIndex] = TaskView.CurTask;
                taskManager.TasksToDo = new List<TaskToDo> (Tasks);
                CloseSecondary();
            }
        }

        /// <summary>
        /// Checks if task is valid
        /// </summary>
        /// <returns></returns>
        private bool CheckValid()
        {
            if (!TaskView.CurTask.ValidInput)
            {
                MessageBox.Show("Description required");
                return false;
            }
            else
                return true;
        }

        public void AboutCommand()
        {
            CurrentView = aboutView;
            OpenSecodaryView();
        }

        /// <summary>
        /// Updates clock in main window
        /// </summary>
        /// <returns></returns>
        private async Task UpdateNow()
        {
            while (true)
            {
                await Task.Delay(100);
                OnPropertyChanged(nameof(Now));
            }
        }




        #endregion

    }
}
