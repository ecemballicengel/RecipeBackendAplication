using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Dtos.Response
{
    public class RecipeDescriptionResponseDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
        public string ImageUrl { get; set; } = "";
    }
}
