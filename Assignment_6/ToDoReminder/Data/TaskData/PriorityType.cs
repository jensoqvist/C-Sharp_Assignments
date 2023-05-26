using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoReminder.Data.TaskData
{
    [Serializable]
    public enum PriorityType
    {
        Very_Important,
        Important,
        Normal,
        Less_Important,
        Not_Important
    }
}
