using Application.Common.Mapping;
using AutoMapper;
using Domain;

namespace Application.Users.Queris.GetUserDetails;

public class UserDetailsVm : IMapWith<User>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public Gender PreferendGender { get; set; }
    public DateTime Created { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserDetailsVm>()
            .ForMember(userVm => userVm.FirstName,
                opt => opt.MapFrom(user => user.FirstName))
            .ForMember(userVm => userVm.LastName,
                opt => opt.MapFrom(user => user.LastName))
            .ForMember(userVm => userVm.Gender,
                opt => opt.MapFrom(user => user.Gender))
            .ForMember(userVm => userVm.PreferendGender,
                opt => opt.MapFrom(user => user.PreferendGender))
            .ForMember(userVm => userVm.Created,
                opt => opt.MapFrom(user => user.Created));
    }
}