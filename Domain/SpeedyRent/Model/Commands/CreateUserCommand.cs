namespace Domain.SpeedyRent.Model.Commands;

public record CreateUserCommand(string Username, string Email, string Password);