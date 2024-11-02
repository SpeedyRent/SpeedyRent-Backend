namespace Domain.SpeedyRent.Model.Commands
{
    public record CreatePostCommand(string Title, string Content, int AuthorId);
}