using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Dtos.Request
{
    public class CreateRecipeDescriptionRequestDto
    {
        public string Description { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public int RecipeId { get; set; }
    }
}
