﻿namespace Recipe.Dtos.Request
{
    public class UpdateRecipeRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string TitleImage { get; set; } = "";
        public int NumberOfPeople { get; set; }
        public int PreparetionTime { get; set; }
        public int CookingTime { get; set; }
        public int CategoryId { get; set; }
    }
}
