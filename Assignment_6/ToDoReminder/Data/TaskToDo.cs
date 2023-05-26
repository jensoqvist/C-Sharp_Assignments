using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoReminder.Data.TaskData;

namespace ToDoReminder.Data
{
    [Serializable]
    public class TaskToDo
    {
        #region fields
        private DateTime date;
        private int hour;
        private int minute;
        private int priority;
        private string description;
        #endregion


        #region propertys
        /// <summary>
        /// date of task
        /// </summary>
        public DateTime Date { get { return date; } set { date = value; } }
        /// <summary>
        /// Hour task shall be done
        /// </summary>
        public int Hour { get { return hour; } set {  hour = value; } }
        /// <summary>
        /// Minute task shall be done
        /// </summary>
        public int Minute { get { return minute; } set { minute = value; } }
        /// <summary>
        /// Priority of task, enum
        /// </summary>
        /// 
        public string Time { get { return string.Format("{0:00}:{1:00}", hour, minute); } }
        public int Priority { get { return priority; } set { priority = value; } } 
        /// <summary>
        /// Priority of task
        /// </summary>
        public string PriorityName { get { return Enum.GetName(typeof(PriorityType), priority); } }
        /// <summary>
        /// Description of task
        /// </summary>
        public string Description { get { return description; } set { description = value; } }

        public bool ValidInput 
        { 
            get 
            { 
                if (Description != null)
                    return true; 
                else 
                    return false;
            } 
        }
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaskToDo() 
        {
            Date = DateTime.Now;
        }
    }
}
