using System;
using System.Windows.Input;

namespace CustomerRegistry.ViewModels
{
    /// <summary>
    /// A basic command that runs an action
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private members
        //Action to run
        private Action mAction;

        #endregion

        #region Public Events
        /// <summary>
        /// the event that is fired when the <see cref="CanExecute(object?)"/> value has changed
        /// </summary>
        public event EventHandler? CanExecuteChanged = (sender, e) => {} ;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RelayCommand(Action action) 
        {
            mAction = action;
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// A rela command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object? parameter)
        { 
            return true; 
        }

        /// <summary>
        /// Executes the commands action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter)
        {
            mAction();
        }

        #endregion
    }
}
