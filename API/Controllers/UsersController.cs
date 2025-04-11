using System.Security.Claims;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

   [Authorize]
public class UsersController(IUserRepository userRepository, IMapper mapper) : BaseApiController
{
    [HttpGet] 
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await userRepository.GetUsersAsync();
        var usersToReturn = mapper.Map<IEnumerable<MemberDto>>(users);
        return Ok(usersToReturn);
    }

 
    //[HttpGet("{id:int}")]
    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUserByName(string username)
    {
        var user = await userRepository.GetUserByUsernameAsync(username);
        if (user == null) return NotFound();

        var userToReturn = mapper.Map<MemberDto>(user);
        return userToReturn;
    }

    [Route("userList/{username}")]
    [HttpGet]
    public async Task<ActionResult<MemberDto>> GetUserByNamelist(string username)
    {
        var user = await userRepository.GetUserByUsernameAsyncList(username);
        if (user == null) return NotFound();

        var userToReturn = mapper.Map<IEnumerable<MemberDto>>(user);
        return Ok(userToReturn);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MemberDto>> GetUser(int id)
    {
        var user = await userRepository.GetUserByIdAsync(id);
        if (user == null) return NotFound();

        var userToReturn = mapper.Map<MemberDto>(user);
        return userToReturn;
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
    {
        //User.ClaimsIdentity; //User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //var claims = User.Claims.ToList();
        if (username == null) return Unauthorized("User not found");
        var user = await userRepository.GetUserByUsernameAsync(username);
        if (user == null) return NotFound();

        mapper.Map(memberUpdateDto, user);

        if (await userRepository.SaveAllAsync()) return NoContent();

        return BadRequest("Failed to update user");
    }
}