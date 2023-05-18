

using RecipeBook.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System;
using RecipeBook.RecipeManager.ViewModels;
using System.Windows.Input;
using System.Windows;
using RecipeBook.Wins;
using System.Linq;
using System.Windows.Navigation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;
using RecipeBook.RecipeManager.Data;

namespace RecipeBook
{
    public class RecipeBookViewModel : BaseViewModel
    {

        #region Private instance variables
        private int maxRecipes = 250;   // Maximum number of recipes the manager handles
        private RecipeBookManager recipeBookManager; // the manager
        private ObservableCollection<Recipe> observableRecipes; // observable list from the array of recipes
        private Recipe curRecipe; // Current recipe
        private AddRecipeWindow addRecipeWindow;
        private ShowRecipeWindow showRecipeWindow;
        private AddIngredientsWindow addIngredientsWindow;
        private int[] categorys;
        private int firstEmpty;
        private int selection;
        private IngredientsViewModel ingredientsViewModel;
        private ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
        private bool enableShow = false;


        #endregion

        #region Public propertys
        /// <summary>
        /// Observable collection of Recepies
        /// </summary>
        public ObservableCollection<Recipe> ObservableRecipes { get { return observableRecipes; } set { observableRecipes = value; OnPropertyChanged(); } }


        /// <summary>
        /// Property holding current recipe
        /// </summary>
        public Recipe CurRecipe
        {
            get => curRecipe;
            set
            {
                curRecipe = value;
                Ingredients = new ObservableCollection<Ingredient>(value.Ingredients);
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Array of integers from Enum FoodCategory
        /// </summary>
        public int[] Categorys { get => categorys; set => categorys = value; }
        /// <summary>
        /// Selection of recipe in listbox, -1 if none
        /// </summary>
        public int Selection
        {
            get => selection;
            set
            {
                selection = value;
                if (value != -1)
                {
                    EnableShow = true;
                    CurRecipe = recipeBookManager.RecipeArray[value];
                }
                else
                {
                    EnableShow = false;
                    CurRecipe = new Recipe();
                }
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// ViewModel for adding ingredients to recipe
        /// </summary>
        public IngredientsViewModel IngredientsVM { get => ingredientsViewModel; set => ingredientsViewModel = value; }
        public ObservableCollection<Ingredient> Ingredients { get => ingredients; set { ingredients = value; OnPropertyChanged(); } }

        public bool EnableShow { get => enableShow; set { enableShow = value; OnPropertyChanged(); } }

        #endregion

        #region Commands

        /// <summary>
        /// Command that shows window for adding new recipes
        /// </summary>
        private ICommand? addCommand;
        public ICommand AddCommand { get { return addCommand; } set { addCommand = value; } }
        /// <summary>
        /// Command that shows window for adding new recipes
        /// </summary>
        private ICommand? editCommand;
        public ICommand EditCommand { get { return editCommand; } set { editCommand = value; } }
        /// <summary>
        /// Command to bring up the window that shows the choosen recipe
        /// </summary>
        private ICommand? showCommand;
        public ICommand ShowCommand { get => showCommand; set => showCommand = value; }

        /// <summary>
        /// Saves recipe to array
        /// </summary>
        private ICommand? saveCommand;
        public ICommand SaveCommand { get => saveCommand; set => saveCommand = value; }

        private ICommand? deleteCommand;
        public ICommand DeleteCommand { get => deleteCommand; set => deleteCommand = value; }

        private ICommand exit;
        public ICommand ExitCommand { get => exit; set => exit = value; }

        private ICommand addIngredientShow;
        public ICommand AddIngredientShow { get => addIngredientShow; set => addIngredientShow = value; }

        private ICommand closeShow;
        public ICommand CloseShow { get => closeShow; set => closeShow = value; }

        private ICommand closeAddIngredient;
        public ICommand CloseAddIngredient { get => closeAddIngredient; set => closeAddIngredient = value; }

        private ICommand clearCommand;
        public ICommand ClearCommand { get => clearCommand; set => clearCommand = value; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RecipeBookViewModel()
        {

            recipeBookManager = new(maxRecipes);
            observableRecipes = new ObservableCollection<Recipe>(recipeBookManager.RecipeArray);
            CurRecipe = new Recipe();
            Categorys = (int[])Enum.GetValues(typeof(FoodCategory));
            Selection = -1;
            #region Initiaztion of relay commands
            ShowCommand = new RelayCommand(Show);
            AddCommand = new RelayCommand(AddNew);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);
            SaveCommand = new RelayCommand(Save);
            ExitCommand = new RelayCommand(ExitApp);
            AddIngredientShow = new RelayCommand(AddIngridientView);
            CloseShow = new RelayCommand(CloseShowRecipe);
            CloseAddIngredient = new RelayCommand(CloseAddIngredients);
            ClearCommand = new RelayCommand(Clear);
            #endregion

        }

        #endregion

        #region Methods
        /// <summary>
        /// Method that makes sure there is space in the recipe array befor opening the add new recipe window
        /// </summary>
        /// <returns></returns>
        private bool CheckEmpty()
        {
            firstEmpty = recipeBookManager.getFirstEmpty();
            if (firstEmpty == -1)
            {
                MessageBox.Show("Recipe list full, please delete some recipe before adding new");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Checks if selection is valid and informs user if not
        /// </summary>
        /// <returns></returns>
        private bool CheckSelection()
        {
            if (Selection == -1 || recipeBookManager.RecipeArray[Selection] == null)
            {
                MessageBox.Show("No valid selection");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Checks if recipe has name and category
        /// </summary>
        /// <returns></returns>
        private bool CheckValidRecipe()
        {
            if (CurRecipe.Name == string.Empty || CurRecipe.Category == -1)
            {
                MessageBox.Show("Please insert recipe name and category to be able to save");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Opens window add/edit Recipe
        /// </summary>
        private void AddRecipeView()
        {
            if (Application.Current.Windows.OfType<AddRecipeWindow>().FirstOrDefault() == null)
            {

                addRecipeWindow = new();
                addRecipeWindow.DataContext = this;
                IngredientsVM = new(CurRecipe);
                if (!CheckEmpty())
                    addRecipeWindow.Close();
                else
                    addRecipeWindow.Show();
            }
        }

        private void ShowRecipeView()
        {
            if (Application.Current.Windows.OfType<ShowRecipeWindow>().FirstOrDefault() == null)
            {
                showRecipeWindow = new();
                showRecipeWindow.DataContext = this;
                showRecipeWindow.Show();
            }

        }

        public void AddIngridientView()
        {
            if (Application.Current.Windows.OfType<AddIngredientsWindow>().FirstOrDefault() == null)
            {
                addIngredientsWindow = new();
                addIngredientsWindow.DataContext = this;
                addIngredientsWindow.Show();
            }
        }

        #region Methods used in commands

        private void Show()
        {
            ShowRecipeView();
        }

        /// <summary>
        /// Command to open add/edit window for a new recipe
        /// </summary>
        private void AddNew()
        {
            CurRecipe = new Recipe() { Category = -1 };
            AddRecipeView();
        }

        /// <summary>
        /// Command to open add/edit window with selected recipe
        /// </summary>
        private void Edit()
        {
            if (CheckSelection())
            {

                CurRecipe = recipeBookManager.RecipeArray[Selection];
                //MessageBox.Show(CurRecipe.Name);
                AddRecipeView();
                firstEmpty = Selection;
                //MessageBox.Show(CurRecipe.Name);
                //Selection = -1;
            }
        }
        /// <summary>
        /// Command to delete selected recipe
        /// </summary>
        private void Delete()
        {
            if (CheckSelection())
            {
                recipeBookManager.RecipeArray[Selection] = null;
                ObservableRecipes = new ObservableCollection<Recipe>(recipeBookManager.RecipeArray);
            }
        }

        /// <summary>
        /// Saves recipe to array
        /// </summary>
        public void Save()
        {
            if (CheckValidRecipe())
            {
                recipeBookManager.addToArray(firstEmpty, CurRecipe);
                ObservableRecipes = new ObservableCollection<Recipe>(recipeBookManager.RecipeArray);
                Selection = -1;
                addRecipeWindow.Close();

            }
        }

        public void Clear()
        { 
            Selection = -1;
        }
        public void CloseShowRecipe()
        {
            showRecipeWindow.Close();
        }

        public void CloseAddIngredients()
        {
            addIngredientsWindow.Close();
        }

        public void ExitApp()
        {
            Application.Current.MainWindow.Close();
            //MainWindow.Close();
        }
        #endregion

        #endregion
    }
}
