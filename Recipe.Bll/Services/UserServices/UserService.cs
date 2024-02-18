using Recipe.Bll.Services.HelperServices;
using Recipe.Dal.DbContexts;
using Recipe.Dtos.Request;
using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly RecipeDbContext _dbContext;
        private readonly IHelperService _helperService;

        public UserService(RecipeDbContext dbContext,IHelperService helperService)
        {
            _dbContext = dbContext;
            _helperService = helperService;
        }
        public void UpdateUserProfile(UpdateUserProfileRequestDto request)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Id == request.UserId && u.IsDeleted == false);

                if (user == null)
                {
                    throw new Exception("Kullanıcı bulunamadı");
                }

                user.UserName = request.UserName;
                user.Email = request.Email;
                user.ImageUrl =_helperService.SaveImage(request.ImageUrl);

                _dbContext.Update(user);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Kullanıcı profili güncellenirken bir hata oluştu");
            }
        }
        public void UpdateUserPassword(UpdateUserPasswordRequestDto request)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Id == request.UserId && u.IsDeleted == false);

                if (user == null)
                {
                    throw new Exception("Kullanıcı bulunamadı");
                }

                if(user.Password != request.Password)
                {
                    throw new Exception("HATALI SIFRE");
                }
                user.Password = request.NewPassword;

                _dbContext.Update(user);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Şifre güncellenirken bir hata oluştu");
            }
        }

        public UserResponseDto GetUserById(GetUserByIdRequestDto request)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Id == request.UserId && u.IsDeleted == false);
                var recipeCount = _dbContext.Recipes.Where(u=> u.CreatedBy == request.UserId).Count();
                if (user == null)
                {
                    throw new Exception("Kullanıcı bulunamadı");
                }

                var userDto = new UserResponseDto
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    ImageUrl = user.ImageUrl,
                    Role = user.Role,
                    RecipeCount = recipeCount,
                    
                };

                return userDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Kullanıcı getirilirken bir hata oluştu");
            }
        }
    }
}
