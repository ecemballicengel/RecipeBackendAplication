using Recipe.Dtos.Request;
using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.UserServices
{
    public interface IUserService
    {
        void UpdateUserProfile(UpdateUserProfileRequestDto request);
        void UpdateUserPassword(UpdateUserPasswordRequestDto request);
        public UserResponseDto GetUserById(GetUserByIdRequestDto request);
    }
}
