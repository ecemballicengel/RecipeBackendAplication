using Recipe.Dal.DbContexts;
using Recipe.Dtos.Request;
using Recipe.Dtos.Response;
using Recipe.Entities;

namespace Recipe.Bll.Services.AmountTypeServices
{
    public class AmountTypeService : IAmountTypeService
    {
        private readonly RecipeDbContext _dbContext;

        public AmountTypeService(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateAmountType(CreateAmountTypeRequestDto request)
        {
            try
            {
                var data = _dbContext.AmountTypes.Add(new AmountTypesEntity
                {
                   Name = request.Name,
                   CreatedAt= DateTime.UtcNow,
                   IsDeleted=false,
                    CreatedBy = StaticValues.UserId
                });
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Miktar tipi eklenemedi");
            }
        }

        public void UpdateAmountType(UpdateAmountTypeRequestDto request)
        {
            try
            {
                var data = _dbContext.AmountTypes.FirstOrDefault(x => x.IsDeleted == false && x.Id == request.Id);
                if (data == null)
                {

                    throw new Exception("Tarif bulunamadı");
                }
                data.Name= request.Name;
                data.UpdatedAt= DateTime.UtcNow;
                data.UpdatedBy = StaticValues.UserId;
                _dbContext.Update(data);
                _dbContext.SaveChanges(true);
            }
            catch (Exception ex)
            {

                throw new Exception("Miktar tipi guncellenemedi");
            }
        }

        public void DeleteAmountType(DeleteAmountTypeRequestDto request)
        {
            try
            {
                var data = _dbContext.AmountTypes.FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);

                if (data == null)
                {
                    throw new Exception("Miktar tipi bulunamadi");
                }
                data.IsDeleted = true;
                _dbContext.Update(data);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Miktar tipi bulunamadi");
            }
        }

        public List<AmountTypeResponseDto> GetAmountTypes()
        {
            try
            {
                var data = _dbContext.AmountTypes
                    .Where(x => x.IsDeleted == false)
                    .Select(x => new AmountTypeResponseDto
                    {
                        Id = x.Id,
                        Name = x.Name
                    })
                    .ToList();

                return data;
            }
            catch (Exception ex)
            {

                throw new Exception("Miktar tipleri listelenemedi");
            }
        }       
    }
}
