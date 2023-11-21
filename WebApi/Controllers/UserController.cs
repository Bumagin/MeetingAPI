using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queris.GetUserDetails;
using Application.Users.Queris.GetUserList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers;


[Route("api/[controller]")]
public class UserController : BaseController
{
    private readonly IMapper _mapper;
    public UserController(IMapper mapper) => _mapper = mapper;
    
    [HttpGet("GetAllUserListAsync")]
    public async Task<ActionResult<UserListVm>> GetAll()
    {
        var query = new GetUserListQuery{};

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpGet("GetUserByIdAsync")]
    public async Task<ActionResult<UserDetailsVm>> Get(Guid id)
    {
        var query = new GetUserDetailsQuery
        {
            Id = id
        };

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost("CreateUser")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto createUserDto)
    {
        var command = _mapper.Map<CreateUserCommand>(createUserDto);
        var userId = await Mediator.Send(command);
        return Ok(userId);
    }

    [HttpPut("UpdateUser")]
    public async Task<ActionResult> Create([FromBody] UpdateUserDto updateUserDto)
    {
        var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
        await Mediator.Send(command);

        return Ok();
    }

    [HttpDelete("DeleteUser")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteUserCommand
        {
            Id = id
        };

        await Mediator.Send(command);

        return Ok();
    }
}