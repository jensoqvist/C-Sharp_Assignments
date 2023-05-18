

using RecipeBook.RecipeManager.Data;
using RecipeBook.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace RecipeBook.RecipeManager.ViewModels
{
    public class IngredientsViewModel : BaseViewModel
    {
        #region private instance varibles
        private Recipe recipe;
        private string name = string.Empty;
        private string amount = string.Empty;
        private ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
        #endregion

        #region public propertys
        /// <summary>
        /// Name of ingredient
        /// </summary>
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        /// <summary>
        /// Amount of ingredient, as string to allow unit etc.
        /// </summary>
        public string Amount { get => amount; set { amount = value; OnPropertyChanged(); } }

        public ObservableCollection<Ingredient> Ingredients { get => ingredients; set { ingredients = value; OnPropertyChanged(); } }
        #endregion

        #region commands
        private ICommand add;
        public ICommand Add { get => add; set => add = value; }

        private ICommand clear;
        public ICommand Clear { get => clear; set => clear = value; }
        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public IngredientsViewModel(Recipe recipeIn)
        {
            //Ingredients = new ObservableCollection<Ingredient>();
            recipe = recipeIn;
            Ingredients = new ObservableCollection<Ingredient>(recipe.Ingredients);
            Add = new RelayCommand(AddIngredient);
            Clear = new RelayCommand(ClearIngredients);
        }

        #region methods
        /// <summary>
        /// Method to add ingrededient, used in command Add
        /// </summary>
        public void AddIngredient()
        {
            if (Name != string.Empty)
            {
                recipe.AddIngredients(name, amount);
                Name = string.Empty;
                Amount = string.Empty;
                Ingredients = new ObservableCollection<Ingredient>(recipe.Ingredients);
            }
            else
                MessageBox.Show("Ingredient name is required");
        }

        /// <summary>
        /// Method to clear ingredient list, used in command Clear
        /// </summary>
        public void ClearIngredients()
        { 
            recipe.Ingredients.Clear();
            Ingredients = new ObservableCollection<Ingredient>(recipe.Ingredients);
        }
        #endregion
    }
}
