using MediatR;

namespace Application.Users.Queris.GetUserDetails;

public class GetUserDetailsQuery : IRequest<UserDetailsVm>
{
    public Guid Id { get; set; }
}