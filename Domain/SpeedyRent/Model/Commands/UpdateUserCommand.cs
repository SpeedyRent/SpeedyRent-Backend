namespace Domain.SpeedyRent.Model.Commands;

public record UpdateUserCommand(int Id, string Username, string Email);