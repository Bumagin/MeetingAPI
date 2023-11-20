using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queris.GetUserDetails;

public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
{
    private readonly IUserDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public GetUserDetailsQueryHandler(IUserDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    
    public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Users.
            FirstOrDefaultAsync(user => 
                user.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        return _mapper.Map<UserDetailsVm>(entity);
    }
}