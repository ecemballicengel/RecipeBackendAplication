using Microsoft.EntityFrameworkCore;
using Recipe.Bll.Services.RecipeDescriptionServices;
using Recipe.Bll.Services.RecipeIngredientServices;
using Recipe.Bll.Services.RecipeServices;
using Recipe.Dtos.Request;
using Recipe.Dtos.Response;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Recipe.Bll.Services.RecipeBusinnessWorkFlowServices
{
    public class RecipeBusinessWorkFlowService : IRecipeBusinessWorkFlowService
    {
        private readonly IRecipeService _recipeService;
        private readonly IRecipeDescriptionService _recipeDescriptionService;
        private readonly IRecipeIngredientService _recipeIngredientService;

        public RecipeBusinessWorkFlowService(IRecipeService recipeService, IRecipeDescriptionService recipeDescriptionService, IRecipeIngredientService recipeIngredientService)
        {
            _recipeService = recipeService;
            _recipeDescriptionService = recipeDescriptionService;
            _recipeIngredientService = recipeIngredientService;

        }

        public void CreateRecipeBusinessWorkFlow(CreateRecipeBusinessWorkFlow request)
        {
            try
            {
                var recipe = _recipeService.AddRecipe(request.AddRecipeRequestDto);

                request.CreateRecipeIngredientRequestDto.ForEach(x => x.RecipeId = recipe);
                _recipeIngredientService.CreateRecipeIngredient(request.CreateRecipeIngredientRequestDto);

                request.CreateRecipeDescriptionRequestDto.ForEach(x => x.RecipeId = recipe);
                _recipeDescriptionService.CreateRecipeDescription(request.CreateRecipeDescriptionRequestDto);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void UpdateRecipeBusinessWorkFlow(UpdateRecipeBusinessWorkFlowRequestDto request)
        {
            try
            {

                _recipeService.UpdateRecipe(request.UpdateRecipeRequestDto);

                _recipeIngredientService.UpdateRecipeIngredient(request.UpdateRecipeIngredientRequestDto);

                _recipeDescriptionService.UpdateRecipeDescription(request.UpdateRecipeDescriptionRequestDto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void DeleteRecipeBusinessWorkFlow(DeleteRecipeBusinessWorkFlowRequestDto request)
        {
            _recipeService.DeleteRecipe(new DeleteRecipeRequestDto { Id = request.RecipeId });
        }

        public GetRecipeBusinessWorkFlowResponseDto GetRecipeBussinessWorkFlow(GetRecipeBusinessWorkFlowRequestDto request)
        {
            var recipe = _recipeService.GetRecipeById(new GetRecipeByIdRequestDto { Id = request.RecipeId });
            var ingredients = _recipeIngredientService.GetRecipeIngredientsByRecipeId(new GetRecipeIngredientsByRecipeIdRequestDto { RecipeId = request.RecipeId });
            var description = _recipeDescriptionService.GetRecipeDescriptionsByRecipeId(new GetRecipeDescriptionByRecipeIdRequestDto { RecipeId = request.RecipeId });

            return new GetRecipeBusinessWorkFlowResponseDto
            {
                Recipe = recipe,
                Ingredients = ingredients,
                Descriptions = description
            };
        }
    }
}
