using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ToDoReminder.ViewModels
{
    internal class AboutViewModel : BaseViewModel
    {
        public UserControl UserControl { get; set; } = new UserControls.AboutView();
        public string Title { get; } = "About this program";
        public string Text { get; } = "Created by Jens for Programming in C# VT 2023";
    }
}
