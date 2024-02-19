namespace Recipe.Dtos.Request
{
    public class UpdateRecipeBusinessWorkFlowRequestDto
    {
        public int RecipeId { get; set; }

        public UpdateRecipeRequestDto UpdateRecipeRequestDto { get; set; }
        public List<UpdateRecipeDescriptionRequestDto> UpdateRecipeDescriptionRequestDto { get; set; }
        public List<UpdateRecipeIngredientRequestDto> UpdateRecipeIngredientRequestDto { get; set; }
    }
}
