
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
        private MenuViewModel menuViewModel = new();
        private BottomBarViewModel bottomBarViewModel = new();


        public BaseViewModel CurrentView { get => currentViewModel; set { currentViewModel = value; OnPropertyChanged(); } }
        /// <summary>
        /// Viewmodel handling adding/editing of tasks
        /// </summary>
        public TaskViewModel TaskView {get => taskViewModel; set { taskViewModel = value; OnPropertyChanged(); } }       
        /// <summary>
        /// ViewModel handling menubar
        /// </summary>
        public MenuViewModel MenuView { get => menuViewModel; set { menuViewModel = value; OnPropertyChanged(); } }
        /// <summary>
        /// Handling buttons att the bottom
        /// </summary>
        public BottomBarViewModel ButtonView { get => bottomBarViewModel; set { bottomBarViewModel = value; OnPropertyChanged(); } }
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
        public ICommand NewTask { get; set; }

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

        }
        #endregion

        #region Methods
        public void OpenSecodaryView()
        {
            if (Application.Current.Windows.OfType<SecondaryWin>().FirstOrDefault() == null)
            {
                SecondaryWin = new();
                SecondaryWin.DataContext = this;
                SecondaryWin.Show();
            }
        }

        public void NewTaskCommand()
        {
            CurrentView = TaskView;
            TaskView.CurTask = new TaskToDo();
            OpenSecodaryView();
        }


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
