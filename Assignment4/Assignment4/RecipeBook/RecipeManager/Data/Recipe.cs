using RecipeBook.RecipeManager.Data;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
    /// <summary>
    /// Class that contains instructions for a recipe
    /// </summary>
    public class Recipe
    {
        #region private instance variables
        /// <summary>
        /// Instance variables backing the public propertys
        /// </summary>
        private string name = string.Empty;
        private int category; //Categorys in enum FoodCategory
        //private string catName;
        private string instructions = string.Empty;
        private List<Ingredient> ingredients = new List<Ingredient>();
        #endregion


        #region Public Propertys

        /// <summary>
        /// Name of the recipe
        /// </summary>
        public string Name { get { return name; } set { name = value; } }
        /// <summary>
        /// Which category the recipe belongs to
        /// </summary>
        public int Category { get { return category; } set { category = value; } }
        public string CatName { get { return Enum.GetName(typeof(FoodCategory), category); } }
        /// <summary>
        /// Instructons for how to cook the recipe
        /// </summary>
        public string Instructions { get { return instructions; } set { instructions = value; } }
        /// <summary>
        /// List that contains all the ingredients for the recipe
        /// </summary>
        public List<Ingredient> Ingredients { get => ingredients; set { ingredients = value; } }
        #endregion

        #region Constructor
        /// <summary>
        /// default constructor for recipes
        /// </summary>
        public Recipe()
        {
            //Ingredients = new Ingredient();
            
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds ingredients to list of ingredients
        /// </summary>
        public void AddIngredients(string name, string amount)
        {
            Ingredients.Add(new Ingredient(name, amount));
        }
        /// <summary>
        /// Clears the list of ingredients
        /// </summary>

        #endregion
    }
}
