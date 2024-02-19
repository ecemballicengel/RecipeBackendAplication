using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Dtos.Response
{
    public class GetRecipeBusinessWorkFlowResponseDto
    {
        public RecipeByIdResponseDto Recipe { get; set; }
        public List<RecipeIngredientResponseDto> Ingredients { get; set; }
        public List<RecipeDescriptionResponseDto> Descriptions { get; set; }
    }
}
