using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ToDoReminder.Data
{
    internal class FileHandler
    {
        /// <summary>
        /// Directory of the app
        /// </summary>
        private string appDir;



        /// <summary>
        /// Default constructor
        /// </summary>
        public FileHandler()
        {
            appDir = AppDomain.CurrentDomain.BaseDirectory;
        }


        public bool CheckExists()
        {
            if(File.Exists(appDir + @"\savedlist.txt"))
                return true;
            return false;
        }

        /// <summary>
        /// Method that writes class to file, serialized
        /// </summary>
        /// <param name="tasks"></param>
        public void BinaryFileWriter(TaskManager tasks)
        {
            using (Stream stream = File.Open(appDir + @"\savedlist.txt", FileMode.Create))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormater = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormater.Serialize(stream, tasks);
            }
        }

        /// <summary>
        /// Reads the serialized class from file and returns the class
        /// </summary>
        /// <returns></returns>
        public TaskManager BinaryReader()
        {
            using (Stream stream = File.Open(appDir + @"\savedlist.txt", FileMode.Open))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormater = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (TaskManager)binaryFormater.Deserialize(stream);
            }
        }
    }
}
