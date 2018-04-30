using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;


namespace WeatherApp.Android
{
    [Activity(Label = "WeatherApp.Android", 
              Theme = "@android:style/Theme.Material.Light", 
              MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Selection);

            Button SearchButton = FindViewById<Button>(Resource.Id.SearchBtn);
            SearchButton.Click += SearchButton_Click;

            Button ButtonResult1 = FindViewById<Button>(Resource.Id.ButtonResult1);
            ButtonResult1.Click += ButtonResult1_Click;

            Button ButtonResult2 = FindViewById<Button>(Resource.Id.ButtonResult2);
            ButtonResult2.Click += ButtonResult2_Click;

            Button ButtonResult3 = FindViewById<Button>(Resource.Id.ButtonResult3);
            ButtonResult3.Click += ButtonResult3_Click;

            Button ButtonResult4 = FindViewById<Button>(Resource.Id.ButtonResult4);
            ButtonResult4.Click += ButtonResult4_Click;

            Button ButtonResult5 = FindViewById<Button>(Resource.Id.ButtonResult5);
            ButtonResult5.Click += ButtonResult5_Click;


        }


        // below function sets up buttons so they may be used to call other functions
        private void SetUpButtons(object sender, EventArgs e)
        {
            Button SearchButton = FindViewById<Button>(Resource.Id.SearchBtn);
            SearchButton.Click += SearchButton_Click;

            Button ButtonResult1 = FindViewById<Button>(Resource.Id.ButtonResult1);
            ButtonResult1.Click += ButtonResult1_Click;

            Button ButtonResult2 = FindViewById<Button>(Resource.Id.ButtonResult2);
            ButtonResult2.Click += ButtonResult2_Click;

            Button ButtonResult3 = FindViewById<Button>(Resource.Id.ButtonResult3);
            ButtonResult3.Click += ButtonResult3_Click;

            Button ButtonResult4 = FindViewById<Button>(Resource.Id.ButtonResult4);
            ButtonResult4.Click += ButtonResult4_Click;

            Button ButtonResult5 = FindViewById<Button>(Resource.Id.ButtonResult5);
            ButtonResult5.Click += ButtonResult5_Click;
        }

        // below fucntion happens whenenver search button is clicked on Selection layout
        private async void SearchButton_Click(object sender, EventArgs e)
        {

            EditText SearchTermTextEntry = FindViewById<EditText>(Resource.Id.SearchTermTextEntry);
            CheckBox GlutenFree = FindViewById<CheckBox>(Resource.Id.GlutenFree);
            CheckBox DairyFree = FindViewById<CheckBox>(Resource.Id.DairyFree);
            CheckBox Vegetarian = FindViewById<CheckBox>(Resource.Id.Vegetarian);

            if (!String.IsNullOrEmpty(SearchTermTextEntry.Text))
            {
                Recipe recipe = await Core.GetRecipe(SearchTermTextEntry.Text, GlutenFree.Checked, DairyFree.Checked, Vegetarian.Checked);
                if (recipe != null)
                {

                    FindViewById<TextView>(Resource.Id.ButtonResult1).Text = recipe.RecipeLabelContent1;
                    FindViewById<TextView>(Resource.Id.ButtonResult1).Visibility = ViewStates.Visible;

                    FindViewById<TextView>(Resource.Id.ButtonResult2).Text = recipe.RecipeLabelContent2;
                    FindViewById<TextView>(Resource.Id.ButtonResult2).Visibility = ViewStates.Visible;

                    FindViewById<TextView>(Resource.Id.ButtonResult3).Text = recipe.RecipeLabelContent3;
                    FindViewById<TextView>(Resource.Id.ButtonResult3).Visibility = ViewStates.Visible;

                    FindViewById<TextView>(Resource.Id.ButtonResult4).Text = recipe.RecipeLabelContent4;
                    FindViewById<TextView>(Resource.Id.ButtonResult4).Visibility = ViewStates.Visible;

                    FindViewById<TextView>(Resource.Id.ButtonResult5).Text = recipe.RecipeLabelContent5;
                    FindViewById<TextView>(Resource.Id.ButtonResult5).Visibility = ViewStates.Visible;

                    FindViewById<TextView>(Resource.Id.CountOfResults).Text = recipe.CountOfResults;

                    // somewhere in this MainActivity.cs file you need to utilize picasso or glide to download images from URL
                }
            }
        }


        //  here on is CODE for the 2nd page (the individual view page)
        //  when this CODE below runs, it uses the text in the search box to pull result *again*
        //  if the results can be stored somewhere 'publically' accessible
        //  then they can just be referenced, and won't have to be pull again for every click
        private async void ButtonResult1_Click(object sender, EventArgs e)
        {
            EditText SearchTermTextEntry = FindViewById<EditText>(Resource.Id.SearchTermTextEntry);
            CheckBox GlutenFree = FindViewById<CheckBox>(Resource.Id.GlutenFree);
            CheckBox DairyFree = FindViewById<CheckBox>(Resource.Id.DairyFree);
            CheckBox Vegetarian = FindViewById<CheckBox>(Resource.Id.Vegetarian);
            SetContentView(Resource.Layout.IndividualView);

            Button ButtonBackToResults = FindViewById<Button>(Resource.Id.btnBackToSearchResults);
            ButtonBackToResults.Click += ButtonBackToResults_Click;
            ButtonBackToResults.Click += SetUpButtons;


            if (!String.IsNullOrEmpty(SearchTermTextEntry.Text))
            {
                Recipe recipe = await Core.GetRecipe(SearchTermTextEntry.Text, GlutenFree.Checked, DairyFree.Checked, Vegetarian.Checked);
                if (recipe != null)
                {
                    FindViewById<TextView>(Resource.Id.RecipeNameResult).Text = recipe.RecipeLabelContent1;
                    FindViewById<TextView>(Resource.Id.IngredientsResult).Text = recipe.IngredientsContent1;
                    FindViewById<TextView>(Resource.Id.WebAddressResult).Text = recipe.RecipeURL1;
                    FindViewById<TextView>(Resource.Id.RecipeImagePlaceholder).Text = recipe.RecipeImageURL1;
                }
            }
        }

        private async void ButtonResult2_Click(object sender, EventArgs e)
        {
            EditText SearchTermTextEntry = FindViewById<EditText>(Resource.Id.SearchTermTextEntry);
            CheckBox GlutenFree = FindViewById<CheckBox>(Resource.Id.GlutenFree);
            CheckBox DairyFree = FindViewById<CheckBox>(Resource.Id.DairyFree);
            CheckBox Vegetarian = FindViewById<CheckBox>(Resource.Id.Vegetarian);
            SetContentView(Resource.Layout.IndividualView);

            Button ButtonBackToResults = FindViewById<Button>(Resource.Id.btnBackToSearchResults);
            ButtonBackToResults.Click += ButtonBackToResults_Click;
            ButtonBackToResults.Click += SetUpButtons;


            if (!String.IsNullOrEmpty(SearchTermTextEntry.Text))
            {
                Recipe recipe = await Core.GetRecipe(SearchTermTextEntry.Text, GlutenFree.Checked, DairyFree.Checked, Vegetarian.Checked);
                if (recipe != null)
                {
                    FindViewById<TextView>(Resource.Id.RecipeNameResult).Text = recipe.RecipeLabelContent2;
                    FindViewById<TextView>(Resource.Id.IngredientsResult).Text = recipe.IngredientsContent2;
                    FindViewById<TextView>(Resource.Id.WebAddressResult).Text = recipe.RecipeURL2;
                    FindViewById<TextView>(Resource.Id.RecipeImagePlaceholder).Text = recipe.RecipeImageURL2;

                }
            }
        }

        private async void ButtonResult3_Click(object sender, EventArgs e)
        {
            EditText SearchTermTextEntry = FindViewById<EditText>(Resource.Id.SearchTermTextEntry);
            CheckBox GlutenFree = FindViewById<CheckBox>(Resource.Id.GlutenFree);
            CheckBox DairyFree = FindViewById<CheckBox>(Resource.Id.DairyFree);
            CheckBox Vegetarian = FindViewById<CheckBox>(Resource.Id.Vegetarian);
            SetContentView(Resource.Layout.IndividualView);

            Button ButtonBackToResults = FindViewById<Button>(Resource.Id.btnBackToSearchResults);
            ButtonBackToResults.Click += ButtonBackToResults_Click;
            ButtonBackToResults.Click += SetUpButtons;


            if (!String.IsNullOrEmpty(SearchTermTextEntry.Text))
            {
                Recipe recipe = await Core.GetRecipe(SearchTermTextEntry.Text, GlutenFree.Checked, DairyFree.Checked, Vegetarian.Checked);
                if (recipe != null)
                {
                    FindViewById<TextView>(Resource.Id.RecipeNameResult).Text = recipe.RecipeLabelContent3;
                    FindViewById<TextView>(Resource.Id.IngredientsResult).Text = recipe.IngredientsContent3;
                    FindViewById<TextView>(Resource.Id.WebAddressResult).Text = recipe.RecipeURL3;
                    FindViewById<TextView>(Resource.Id.RecipeImagePlaceholder).Text = recipe.RecipeImageURL3;

                }
            }
        }

        private async void ButtonResult4_Click(object sender, EventArgs e)
        {
            EditText SearchTermTextEntry = FindViewById<EditText>(Resource.Id.SearchTermTextEntry);
            CheckBox GlutenFree = FindViewById<CheckBox>(Resource.Id.GlutenFree);
            CheckBox DairyFree = FindViewById<CheckBox>(Resource.Id.DairyFree);
            CheckBox Vegetarian = FindViewById<CheckBox>(Resource.Id.Vegetarian);
            SetContentView(Resource.Layout.IndividualView);

            Button ButtonBackToResults = FindViewById<Button>(Resource.Id.btnBackToSearchResults);
            ButtonBackToResults.Click += ButtonBackToResults_Click;
            ButtonBackToResults.Click += SetUpButtons;


            if (!String.IsNullOrEmpty(SearchTermTextEntry.Text))
            {
                Recipe recipe = await Core.GetRecipe(SearchTermTextEntry.Text, GlutenFree.Checked, DairyFree.Checked, Vegetarian.Checked);
                if (recipe != null)
                {
                    FindViewById<TextView>(Resource.Id.RecipeNameResult).Text = recipe.RecipeLabelContent4;
                    FindViewById<TextView>(Resource.Id.IngredientsResult).Text = recipe.IngredientsContent4;
                    FindViewById<TextView>(Resource.Id.WebAddressResult).Text = recipe.RecipeURL4;
                    FindViewById<TextView>(Resource.Id.RecipeImagePlaceholder).Text = recipe.RecipeImageURL4;

                }
            }
        }

        private async void ButtonResult5_Click(object sender, EventArgs e)
        {
            EditText SearchTermTextEntry = FindViewById<EditText>(Resource.Id.SearchTermTextEntry);
            CheckBox GlutenFree = FindViewById<CheckBox>(Resource.Id.GlutenFree);
            CheckBox DairyFree = FindViewById<CheckBox>(Resource.Id.DairyFree);
            CheckBox Vegetarian = FindViewById<CheckBox>(Resource.Id.Vegetarian);
            SetContentView(Resource.Layout.IndividualView);

            Button ButtonBackToResults = FindViewById<Button>(Resource.Id.btnBackToSearchResults);
            ButtonBackToResults.Click += ButtonBackToResults_Click;
            ButtonBackToResults.Click += SetUpButtons;


            if (!String.IsNullOrEmpty(SearchTermTextEntry.Text))
            {
                Recipe recipe = await Core.GetRecipe(SearchTermTextEntry.Text, GlutenFree.Checked, DairyFree.Checked, Vegetarian.Checked);
                if (recipe != null)
                {
                    FindViewById<TextView>(Resource.Id.RecipeNameResult).Text = recipe.RecipeLabelContent5;
                    FindViewById<TextView>(Resource.Id.IngredientsResult).Text = recipe.IngredientsContent5;
                    FindViewById<TextView>(Resource.Id.WebAddressResult).Text = recipe.RecipeURL5;
                    FindViewById<TextView>(Resource.Id.RecipeImagePlaceholder).Text = recipe.RecipeImageURL5;

                }
            }
        }

        // below function sets to Selection.AXML
        private void ButtonBackToResults_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Selection);
        }
    }
}