using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Dtos.Request
{
    public class RegisterRequestDto
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public string ControlPassword { get; set; } = "";
        public string Email { get; set; } = "";
    }
}
