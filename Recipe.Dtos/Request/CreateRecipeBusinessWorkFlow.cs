namespace Recipe.Dtos.Request
{
    public class CreateRecipeBusinessWorkFlow
    {
        public AddRecipeRequestDto? AddRecipeRequestDto { get; set; }
        public List<CreateRecipeIngredientRequestDto>? CreateRecipeIngredientRequestDto { get; set; }
        public List<CreateRecipeDescriptionRequestDto>? CreateRecipeDescriptionRequestDto { get; set;}


    }
}
