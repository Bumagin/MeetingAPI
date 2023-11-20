using Domain;
using MediatR;

namespace Application.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public Gender PreferendGender { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}