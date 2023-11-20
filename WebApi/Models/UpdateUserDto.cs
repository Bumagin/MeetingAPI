using Application.Common.Mapping;
using Application.Users.Commands.UpdateUser;
using AutoMapper;
using Domain;

namespace WebApi.Models;

public class UpdateUserDto : IMapWith<UpdateUserCommand>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public Gender PreferendGender { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
            .ForMember(userCommand => userCommand.FirstName,
                opt => opt.MapFrom(userDto => userDto.FirstName))
            .ForMember(userCommand => userCommand.LastName,
                opt => opt.MapFrom(userDto => userDto.LastName))
            .ForMember(userCommand => userCommand.Gender,
                opt => opt.MapFrom(userDto => userDto.Gender))
            .ForMember(userCommand => userCommand.PreferendGender,
                opt => opt.MapFrom(userDto => userDto.PreferendGender))
            .ForMember(userCommand => userCommand.Email,
                opt => opt.MapFrom(userDto => userDto.Email))
            .ForMember(userCommand => userCommand.Password,
                opt => opt.MapFrom(userDto => userDto.Password));
    }
}