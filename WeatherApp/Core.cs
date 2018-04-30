using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Core
    {
        public static async Task<Recipe> GetRecipe(string searchTerm, bool GlutenFree, bool DairyFree, bool Vegetarian)
        {
            string HealthParam = "";

            if(GlutenFree || DairyFree || Vegetarian == true)
            {
                HealthParam = "?";
            }
            
            if(GlutenFree == true)
            {
                HealthParam += "health=gluten-free";
            }

            if(DairyFree == true)
            {
                if(GlutenFree == true)
                {
                    HealthParam += "&";
                }

                HealthParam += "health=gluten-free";
            }

            if(Vegetarian == true)
            {
                if(GlutenFree || Vegetarian == true)
                {
                    HealthParam += "&";
                }

                HealthParam += "health=vegetarian";
            }


            // **START recipe search API
            // documentation https://developer.edamam.com/edamam-docs-recipe-api

            string key = "4f9099da52f998eb02261e0714715495";
            string id = "cfafedc8";
            string queryString = "https://api.edamam.com/search?q=" + /* URI encoding */ System.Uri.EscapeUriString(searchTerm) + HealthParam + "&app_id=" + id + "&app_key=" + key;
            // **END recipe search API

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(true);

            Recipe recipe = new Recipe();

            //count of search results
            recipe.CountOfResults = (string)results["count"];

            // recipe name
            recipe.RecipeLabelContent1 = (string)results["hits"][0]["recipe"]["label"];
            recipe.RecipeLabelContent2 = (string)results["hits"][1]["recipe"]["label"];
            recipe.RecipeLabelContent3 = (string)results["hits"][2]["recipe"]["label"];
            recipe.RecipeLabelContent4 = (string)results["hits"][3]["recipe"]["label"];
            recipe.RecipeLabelContent5 = (string)results["hits"][4]["recipe"]["label"];

            // loop to put all ingredients in ingredient JSON array in single string
            for (int i = 0; i < (results["hits"][0]["recipe"]["ingredients"].Count); i++)
            {
                recipe.IngredientsContent1 += ((string)results["hits"][0]["recipe"]["ingredients"][i]["text"] + "\n");
            }

            for (int i = 0; i < (results["hits"][1]["recipe"]["ingredients"].Count); i++)
            {
                recipe.IngredientsContent2 += ((string)results["hits"][1]["recipe"]["ingredients"][i]["text"] + "\n");
            }

            for (int i = 0; i < (results["hits"][2]["recipe"]["ingredients"].Count); i++)
            {
                recipe.IngredientsContent3 += ((string)results["hits"][2]["recipe"]["ingredients"][i]["text"] + "\n");
            }

            for (int i = 0; i < (results["hits"][3]["recipe"]["ingredients"].Count); i++)
            {
                recipe.IngredientsContent4 += ((string)results["hits"][3]["recipe"]["ingredients"][i]["text"] + "\n");
            }

            for (int i = 0; i < (results["hits"][4]["recipe"]["ingredients"].Count); i++)
            {
                recipe.IngredientsContent5+= ((string)results["hits"][4]["recipe"]["ingredients"][i]["text"] + "\n");
            }

            // recipe URL
            recipe.RecipeURL1 = (string)results["hits"][0]["recipe"]["url"];
            recipe.RecipeURL2 = (string)results["hits"][1]["recipe"]["url"];
            recipe.RecipeURL3 = (string)results["hits"][2]["recipe"]["url"];
            recipe.RecipeURL4 = (string)results["hits"][3]["recipe"]["url"];
            recipe.RecipeURL5 = (string)results["hits"][4]["recipe"]["url"];
            // recipe image URL
            recipe.RecipeImageURL1 = (string)results["hits"][0]["recipe"]["image"];
            recipe.RecipeImageURL2 = (string)results["hits"][1]["recipe"]["image"];
            recipe.RecipeImageURL3 = (string)results["hits"][2]["recipe"]["image"];
            recipe.RecipeImageURL4 = (string)results["hits"][3]["recipe"]["image"];
            recipe.RecipeImageURL5 = (string)results["hits"][4]["recipe"]["image"];

            return recipe;

        }

    }
}