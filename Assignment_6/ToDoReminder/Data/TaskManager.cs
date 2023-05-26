using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using ToDoReminder.Data;

namespace ToDoReminder
{
    [Serializable]
    public class TaskManager
    {
        #region fields
        private List<TaskToDo> tasks = new List<TaskToDo>();
        #endregion

        #region propertys
        /// <summary>
        /// List of tasks
        /// </summary>
        public List<TaskToDo> TasksToDo { get => tasks; set => tasks = value; }
        #endregion

        #region constructor
        /// <summary>
        /// Default construktor
        /// </summary>
        public TaskManager() 
        {
            //TestTasks testTasks = new TestTasks();
            //TasksToDo = testTasks.Tasks;

        }
        #endregion

        #region methods

        #endregion
    }
}
