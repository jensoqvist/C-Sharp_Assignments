using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToDoReminder.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {

        public ICommand Save { get; set; }

        public MenuViewModel() 
        {
            Save = new RelayCommand(SaveCommand);
        }

        public void SaveCommand()
        {
            
            

        }
    }
}
