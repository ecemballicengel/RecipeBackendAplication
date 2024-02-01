using Recipe.Dtos.Request;
using Recipe.Dtos.Response;

namespace Recipe.Bll.Services.AmountTypeServices
{
    public interface IAmountTypeService
    {
        void CreateAmountType(CreateAmountTypeRequestDto request);
        void UpdateAmountType(UpdateAmountTypeRequestDto request);
        void DeleteAmountType(DeleteAmountTypeRequestDto request);

        List<AmountTypeResponseDto> GetAmountTypes();
    } 
}
