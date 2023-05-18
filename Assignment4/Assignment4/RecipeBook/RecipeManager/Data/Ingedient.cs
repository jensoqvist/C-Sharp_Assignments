
using RecipeBook.Wins;
using System.Collections.Generic;
using System.Windows;

namespace RecipeBook.RecipeManager.Data
{
    /// <summary>
    /// Class that describes ingredients needed for the recipe
    /// </summary>
    public class Ingredient
    {
        #region privagte instance variables
        private string ingredientName = string.Empty;
        private string ingredientAmount = string.Empty;
        #endregion

        #region Public Propertys
        /// <summary>
        /// the name of the ingredient
        /// </summary>
        public string Name { get => ingredientName; set => ingredientName = value; }
        /// <summary>
        /// how much of the ingredient that is needed
        /// </summary>
        public string Amount { get => ingredientAmount;set => ingredientAmount = value; }
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="name"> the name of the ingredient</param>
        /// <param name="amount"> how much of the ingredient that is needed</param>
        public Ingredient(string name, string amount) 
        {
            Name = name;
            Amount = amount;
        }
        #endregion

    }
}
