using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IUserDbContext _dbContext;
    
    public UpdateUserCommandHandler(IUserDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Users.FirstOrDefaultAsync(
            user => user.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        entity.FirstName = request.FirstName;
        entity.LastName = request.LastName;
        entity.Gender = request.Gender;
        entity.PreferendGender = request.PreferendGender;
        entity.Email = request.Email;
        entity.Password = request.Password;
        entity.Updated = DateTime.Now;
        
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    
}