using Recipe.Bll.Services.TokenServices;
using Recipe.Dal.DbContexts;
using Recipe.Dtos.Request;
using Recipe.Dtos.Response;
using Recipe.Entities;

namespace Recipe.Bll.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly RecipeDbContext _dbContext;
        private readonly ITokenService _tokenService;

        public LoginService(RecipeDbContext dbContext, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }
        public LoginResponseDto Login(LoginRequestDto request)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(x =>
                x.IsDeleted == false
                && (x.UserName == request.UserName || x.Email == request.Email));

                if (user == null)
                {
                    throw new Exception("Hatali Kullanici girisi");
                }

                CheckPassword(request.Password, user);
                CheckRetryCount(user);

                user.RetryCount = 0;

                var token = _tokenService.GenerateToken(new GenerateTokenRequestDto
                {
                    Role = user.Role,
                    UserName = user.UserName
                });

                user.AuthToken = token.Token;
                user.AccessTokenExpireDate = token.TokenExpireDate;
                UpdateUser(user);

                return new LoginResponseDto
                {
                    AuthenticateResult = true,
                    AccessTokenExpireDate = token.TokenExpireDate,
                    AuthToken = token.Token
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void CheckPassword(string password, UserEntity user)
        {
            bool checkPassword = user.Password == password;

            if (!checkPassword)
            {
                user.RetryCount++;
                UpdateUser(user);
                throw new Exception("Kullanci Adi veya Sifre Hatali");
            }
        }

        private void CheckRetryCount(UserEntity user)
        {
            var checkRetryCount = user.RetryCount > 3;

            if (checkRetryCount)
            {
                throw new Exception("Kullanici hesabiniz bloke olmustur. Sifre sifirlama adimina gidiniz");
            }
        }
        private void UpdateUser(UserEntity entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
