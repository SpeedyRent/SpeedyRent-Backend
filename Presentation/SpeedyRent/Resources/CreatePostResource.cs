namespace Presentation.SpeedyRent.Resources

{
    public record CreatePostResource(string Title, string Content, int AuthorId);
    
    public record UpdatePostResource(string Title, string Content);
}