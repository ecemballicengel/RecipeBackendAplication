using Recipe.Bll.Services.RecipeDescriptionServices;
using Recipe.Bll.Services.RecipeIngredientServices;
using Recipe.Bll.Services.RecipeServices;
using Recipe.Dtos.Request;

namespace Recipe.Bll.Services.RecipeBusinnessWorkFlowServices
{
    public class RecipeBusinessWorkFlowService : IRecipeBusinessWorkFlowService
    {
        private readonly IRecipeService _recipeService;
        private readonly IRecipeDescriptionService _recipeDescriptionService;
        private readonly IRecipeIngredientService _recipeIngredientService;

        public RecipeBusinessWorkFlowService(IRecipeService recipeService,IRecipeDescriptionService recipeDescriptionService, IRecipeIngredientService recipeIngredientService)
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
    }
}
