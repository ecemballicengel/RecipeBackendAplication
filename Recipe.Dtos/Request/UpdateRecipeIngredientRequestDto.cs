using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Dtos.Request
{
    public class UpdateRecipeIngredientRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public double Amount { get; set; }
        public int AmountTypeId { get; set; }
        public int RecipeId { get; set; }
    }
}
