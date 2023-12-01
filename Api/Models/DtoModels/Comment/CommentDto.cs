namespace Api.Models.DtoModels.Comment
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public Guid PostId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
