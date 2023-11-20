using Application.Common.Mapping;
using AutoMapper;
using Domain;

namespace Application.Users.Queris.GetUserList;

public class UserLookupDto : IMapWith<User>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public Gender PreferendGender { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserLookupDto>()
            .ForMember(userDto => userDto.Id,
                opt => opt.MapFrom(user => user.Id))
            .ForMember(userDto => userDto.FirstName,
                opt => opt.MapFrom(user => user.FirstName))
            .ForMember(userDto => userDto.LastName,
                opt => opt.MapFrom(user => user.LastName))
            .ForMember(userDto => userDto.Gender,
                opt => opt.MapFrom(user => user.Gender))
            .ForMember(userDto => userDto.PreferendGender,
                opt => opt.MapFrom(user => user.PreferendGender));
    }
}