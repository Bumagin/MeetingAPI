using Application.Interfaces;
using Application.Users.Queris.GetUserDetails;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queris.GetUserList;

public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListVm>
{
    private readonly IUserDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserListQueryHandler(IUserDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<UserListVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var usersQuery =  await _dbContext.Users.
            ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider).
            ToListAsync(cancellationToken);

        return new UserListVm { Users = usersQuery };
    }
}