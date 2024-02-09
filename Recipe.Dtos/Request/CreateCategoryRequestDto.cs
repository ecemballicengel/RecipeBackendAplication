namespace Recipe.Dtos.Request
{
    public class CreateCategoryRequestDto
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string ImageUrl { get; set; } = "";
    }
}
