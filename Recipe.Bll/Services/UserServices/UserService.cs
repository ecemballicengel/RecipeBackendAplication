﻿using Recipe.Dal.DbContexts;
using Recipe.Dtos.Request;
using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly RecipeDbContext _dbContext;

        public UserService(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;
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
                user.ImageUrl = request.ImageUrl;

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

                user.Password = request.Password;

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
