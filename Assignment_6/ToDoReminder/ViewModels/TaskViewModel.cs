using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ToDoReminder.Data;
using ToDoReminder.Data.TaskData;

namespace ToDoReminder.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        #region init
        
        public UserControl UserControl { get; set; } = new UserControls.TaskView();
        #endregion

        #region fields
        private TaskToDo curTask;
        #endregion

        #region propertys
        public string Title { get; set; }
        public bool NewTask { get; set; } = false;
        public TaskToDo CurTask { get { return curTask; } set {  curTask = value; OnPropertyChanged(); } }
        public int[] PriorityType { get; set; } = (int[]) Enum.GetValues(typeof(PriorityType));
        /// <summary>
        /// Hour task starts
        /// </summary>
        public int[] Hour { get { return Enumerable.Range(0, 24).ToArray(); } }
    
        /// <summary>
        /// Minute in hour
        /// </summary>
        public int[] Minute { get; } = new int[] { 0, 15, 30, 45 };
        
        #endregion


        public TaskViewModel()
        {

        }



}
}
