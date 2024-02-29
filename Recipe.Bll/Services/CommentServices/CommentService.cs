using Microsoft.EntityFrameworkCore;
using Recipe.Bll.Services.HelperServices;
using Recipe.Dal.DbContexts;
using Recipe.Dtos.Request;
using Recipe.Dtos.Response;
using Recipe.Entities;

namespace Recipe.Bll.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly RecipeDbContext _dbContext;

        public CommentService(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateComment(CreateCommentRequestDto request)
        {
            try
            {
                var comment = _dbContext.Comments.Add(new CommentEntity
                {
                    Comment = request.Comment,
                    CreatedAt = DateTime.Now,
                    CreatedBy = StaticValues.UserId,
                    RecipeId = request.RecipeId,
                    IsDeleted = false,
                });
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Yorum eklenemedi");
            }

        }

        public void UpdateComment(UpdateCommentRequestDto request)
        {
            try
            {
                var existingComment = _dbContext.Comments.FirstOrDefault(x => x.IsDeleted == false && x.Id == request.Id);

                if (existingComment == null)
                {
                    throw new Exception("Yorum bulunamadı");
                }

                if(existingComment.CreatedBy !=  StaticValues.UserId)
                {
                    throw new Exception("Baska kullanicinin verisini guncelleyemezsiniz");                }
                existingComment.Id = request.Id;
                existingComment.Comment = request.Comment;
                existingComment.RecipeId = request.RecipeId;
                existingComment.CreatedAt = request.CreatedAt;
                existingComment.CreatedBy = StaticValues.UserId;
                existingComment.UpdatedAt = DateTime.Now;
                existingComment.UpdatedBy = StaticValues.UserId;

                _dbContext.Update(existingComment);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Yorum guncellenemedi");
            }
        }

        public void DeleteComment(DeleteCommentRequestDto request)
        {
            try
            {
                var existingComment = _dbContext.Comments.FirstOrDefault(r => r.Id == request.Id && r.IsDeleted == false);

                if (existingComment == null)
                {
                    throw new Exception("Yorum bulunamadi");
                }
                existingComment.IsDeleted = true;

                _dbContext.Update(existingComment);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Yorum bulunamadi");
            }
        }
        public CommentResponseDto GetCommentById(GetCommentByIdRequestDto request)
        {
            var data = _dbContext.Comments.FirstOrDefault(x => x.RecipeId == request.Id && x.IsDeleted == false);
            if (data == null)
                return new CommentResponseDto();

            UserEntity? user = _dbContext.Users.FirstOrDefault(x => x.Id == data.CreatedBy);
            var response = new CommentResponseDto()
            {
                Id = data.Id,
                Comment = data.Comment,
                RecipeId = data.RecipeId,
                CreatedAt = DateTime.Now,
                UserName = user?.UserName ?? "",
                UserImage = user?.ImageUrl ?? "",
                UserId = user?.Id??0,

            };
            return response;
        }
        public List<CommentResponseDto> GetAllComment()
        {
            try
            {
                var comments = _dbContext.Comments.Where(x => x.IsDeleted == false).ToList();

                var response = new List<CommentResponseDto>();

                foreach (var comment in comments)
                {
                    UserEntity? user = _dbContext.Users.FirstOrDefault(x => x.Id == comment.CreatedBy);

                    response.Add(new CommentResponseDto
                    {
                        Id = comment.Id,
                        Comment = comment.Comment,
                        RecipeId = comment.RecipeId,
                        CreatedAt = DateTime.Now,
                        UserName = user?.UserName ?? "",
                        UserImage = user?.ImageUrl ?? "",
                        UserId = user?.Id ?? 0,
                    });
                }

                return response;
            }
            catch (Exception ex)
            {

                throw new Exception("Yorumlar listelenemedi");
            }

        }
    }
}

