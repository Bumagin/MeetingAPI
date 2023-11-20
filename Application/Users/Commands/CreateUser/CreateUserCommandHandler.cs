using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserDbContext _dbContext;

    public CreateUserCommandHandler(IUserDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Gender = request.Gender,
            PreferendGender = request.PreferendGender,
            Email = request.Email,
            Password = request.Password,
            Created = DateTime.Now
        };

        await _dbContext.Users.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return user.Id;
    }
}