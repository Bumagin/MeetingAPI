using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserDbContext _dbContext;
    
    public DeleteUserCommandHandler(IUserDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Users
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        _dbContext.Users.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}