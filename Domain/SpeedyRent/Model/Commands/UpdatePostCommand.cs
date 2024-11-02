namespace Domain.SpeedyRent.Model.Commands
{
    public record UpdatePostCommand(int Id, string Title, string Content);
}