using Recipe.Dtos.Request;
using Recipe.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Bll.Services.RecipeBusinnessWorkFlowServices
{
    public interface IRecipeBusinessWorkFlowService
    {
        void CreateRecipeBusinessWorkFlow(CreateRecipeBusinessWorkFlow request);
        void UpdateRecipeBusinessWorkFlow(UpdateRecipeBusinessWorkFlowRequestDto request);
        void DeleteRecipeBusinessWorkFlow(DeleteRecipeBusinessWorkFlowRequestDto request);
        GetRecipeBusinessWorkFlowResponseDto GetRecipeBussinessWorkFlow(GetRecipeBusinessWorkFlowRequestDto request);
    }
}
