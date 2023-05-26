using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToDoReminder.Data;

namespace ToDoReminder.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {



        public ICommand Exit { get; set; }

        public MenuViewModel() 
        {

            Exit = new RelayCommand(ExitCommand);  
        }



        public void ExitCommand()
        {
            Application.Current.MainWindow.Close();
        }


    }
}
