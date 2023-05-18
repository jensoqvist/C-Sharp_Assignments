using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoReminder.Data
{
    internal class TestTasks
    {

        public List<TaskToDo> Tasks { get; set; } = new();

        public TestTasks() 
        {
            Tasks.Add(
                new TaskToDo() { Date = new DateTime(2023, 05, 16),
                Hour = 12,
                Minute = 30,
                Priority = 1,
                Description ="Test Task"}) ;
            Tasks.Add(
                new TaskToDo()
                {
                    Date = new DateTime(2023, 05, 17),
                    Hour = 12,
                    Minute = 45,
                    Priority = 2,
                    Description = "Another Test Task"
                });

        }




    }
}
