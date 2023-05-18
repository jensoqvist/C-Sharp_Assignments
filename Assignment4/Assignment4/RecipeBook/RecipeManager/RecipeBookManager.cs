

using System;
using System.Windows;

namespace RecipeBook
{
    public class RecipeBookManager
    {


        #region private instance variables
        /// <summary>
        /// Array of recipes
        /// </summary>
        private Recipe[] recipeArray;
        private int maxNum;
        #endregion

        #region Public propertys
        public Recipe[] RecipeArray { get { return recipeArray; } set { recipeArray = value; } }

        #endregion

        #region Constructor
        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="maxRecipes"> the maximum number of recipes the array can contain</param>
        public RecipeBookManager(int maxRecipes)
        {
            maxNum= maxRecipes;
            RecipeArray = new Recipe[maxNum];
            //RecipeArray[0] = new Recipe();
            //RecipeArray[0].Name = "TestRecipe";
            //RecipeArray[0].Category = 3;


        }
        #endregion

        #region Methods
        public int getFirstEmpty()
        {
            int index = -1;
            for (int i = 0; i < maxNum; i++)
            {
                if (RecipeArray[i] == null)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }


        public void addToArray(int index, Recipe newRecipe)
        {
            RecipeArray[index] = newRecipe;
        }

        #endregion
    }

}
