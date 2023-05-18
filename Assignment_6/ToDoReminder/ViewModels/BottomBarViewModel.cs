using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToDoReminder.ViewModels
{
    public class BottomBarViewModel : BaseViewModel
    {

        public ICommand Add { get; set; }
        public ICommand Edit { get; set; }
        public ICommand Delete { get; set; }


        public BottomBarViewModel() 
        {
            Add = new RelayCommand(AddCommand);
            Edit = new RelayCommand(EditCommand);
            Delete = new RelayCommand(DeleteCommand);
        }

        public void AddCommand()
        {

        }

        public void EditCommand()
        {

        }

        public void DeleteCommand()
        {

        }
    }
}
