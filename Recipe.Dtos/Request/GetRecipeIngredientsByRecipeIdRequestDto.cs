using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Dtos.Request
{
    public class GetRecipeIngredientsByRecipeIdRequestDto
    {
        public int RecipeId { get; set; }
    }
}
