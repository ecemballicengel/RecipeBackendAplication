using Recipe.Dal.DbContexts;
using Recipe.Dtos.Request;
using Recipe.Entities;

namespace Recipe.Bll.Services.RegisterServices
{
    public class RegisterService : IRegisterService
    {
        private readonly RecipeDbContext _dbcontext;

        public RegisterService(RecipeDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void RegisterUser(RegisterRequestDto request)
        {
           var user = _dbcontext.Users.FirstOrDefault(x=> x.UserName == request.UserName );
            if (user != null)
            {
                throw new Exception("Kullanici adi zaten mevcut");
            }
            var email = _dbcontext.Users.FirstOrDefault(x=> x.Email == request.Email);
            if (email != null)
            {
                throw new Exception("Email zaten mevcut");
            }

            if (request.Password != request.ControlPassword)
            {
                throw new Exception("Girilen şifreler uyuşmamaktadır.");
            }

            var newUser = new UserEntity
            {
                UserName = request.UserName,
                Password = request.Password, 
                Email = request.Email,
                CreatedAt = DateTime.UtcNow,
                IsDeleted=false,
                Role="user",
                RetryCount=0,
                
            };
            _dbcontext.Users.Add(newUser);
            _dbcontext.SaveChanges();
        }
    }
}
