//using System;
//using Android.App;
//using Android.Widget;
//using Android.OS;

//namespace WeatherApp.Android
//{
//    [Activity(Label = "WeatherApp.Android", 
//              Theme = "@android:style/Theme.Material.Light", 
//              MainLauncher = true)]
//    public class IndividualView : Activity
//    {
//        protected override void OnCreate(Bundle savedInstanceState)
//        {
//            base.OnCreate(savedInstanceState);

//            // Set our view from the "main" layout resource
//            SetContentView(Resource.Layout.IndividualView);

//            Button btnBackToSearchResults = FindViewById<Button>(Resource.Id.btnBackToSearchResults);
//            btnBackToSearchResults.Click += btnBackToSearchResults_Click;

//            if (!String.IsNullOrEmpty(SearchTermTextEntry.Text))
//            {
//                Recipe recipe = await Core.GetRecipe(SearchTermTextEntry.Text);
//                if (recipe != null)
//                {
//                    FindViewById<TextView>(Resource.Id.RecipeNameResult).Text = recipe.RecipeLabelContent1;
//                    FindViewById<TextView>(Resource.Id.IngredientsResult).Text = recipe.IngredientsContent;
//                    FindViewById<TextView>(Resource.Id.WebAddressResult).Text = recipe.RecipeURL;
//                }
//            }
//        }

//        private void btnBackToSearchResults_Click(object sender, EventArgs e)
//        {
//            SetContentView(Resource.Layout.Selection);
//        }

//        private async void SearchButton_Click(object sender, EventArgs e)
//        {
//            EditText SearchTermTextEntry = FindViewById<EditText>(Resource.Id.SearchTermTextEntry);

//            if (!String.IsNullOrEmpty(SearchTermTextEntry.Text))
//            {
//                Recipe recipe = await Core.GetRecipe(SearchTermTextEntry.Text);
//                if (recipe != null)
//                {

//                    FindViewById<TextView>(Resource.Id.ButtonResult1).Text = recipe.RecipeLabelContent1;
//                    FindViewById<TextView>(Resource.Id.ButtonResult2).Text = recipe.RecipeLabelContent2;
//                    FindViewById<TextView>(Resource.Id.ButtonResult3).Text = recipe.RecipeLabelContent3;
//                    FindViewById<TextView>(Resource.Id.ButtonResult4).Text = recipe.RecipeLabelContent4;
//                    FindViewById<TextView>(Resource.Id.ButtonResult5).Text = recipe.RecipeLabelContent5;
//                    FindViewById<TextView>(Resource.Id.CountOfResults).Text = recipe.CountOfResults;

//                    // somewhere in this MainActivity.cs file you need to utilize picasso or glide to download images from URL
//                }
//            }
//        }

//        private async void ButtonResult1_Click(object sender, EventArgs e)
//        {
//            EditText SearchTermTextEntry = FindViewById<EditText>(Resource.Id.SearchTermTextEntry);
//            SetContentView(Resource.Layout.IndividualView);

//            Button ButtonBackToResults = FindViewById<Button>(Resource.Id.btnBackToSearchResults);
//            ButtonBackToResults.Click += ButtonBackToResults_Click;


//            if (!String.IsNullOrEmpty(SearchTermTextEntry.Text))
//            {
//                Recipe recipe = await Core.GetRecipe(SearchTermTextEntry.Text);
//                if (recipe != null)
//                {
//                    FindViewById<TextView>(Resource.Id.RecipeNameResult).Text = recipe.RecipeLabelContent1;
//                    FindViewById<TextView>(Resource.Id.IngredientsResult).Text = recipe.IngredientsContent;
//                    FindViewById<TextView>(Resource.Id.WebAddressResult).Text = recipe.RecipeURL;
//                }
//            }
//        }

//        private void ButtonBackToResults_Click(object sender, EventArgs e)
//        {
//            SetContentView(Resource.Layout.Selection);
//        }
//    }
//}