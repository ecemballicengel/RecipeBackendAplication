using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Dtos.Response
{
    public class UserResponseDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public int RecipeCount { get; set; }
        public string Role { get; set; } = "";
    }
}
