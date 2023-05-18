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
        public string Title { get; set; } = "New Task";
        public UserControl UserControl { get; set; } = new UserControls.TaskView();
        #endregion

        #region fields
        private TaskToDo curTask;
        #endregion

        #region propertys
        public TaskToDo CurTask { get { return curTask; } set {  curTask = value; OnPropertyChanged(); } }
        public int[] PriorityType { get; set; } = (int[]) Enum.GetValues(typeof(PriorityType));

        public string Test { get; set; } = "test"; 
        #endregion


        public TaskViewModel()
        {

        }

}
}
