using AutoMapper;
using DFAWebApp.API.Dtos;
using DFAWebApp.Domain.Interfaces;
using DFAWebApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DFAWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : MainController
    {
        private IUserService _userService;
        private IMapper _mapper;

        private IConfiguration _config;

        public UserController( IUserService userService, IMapper mapper, IConfiguration config)
        {
            _userService = userService;
            _mapper = mapper;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserResultDto userResultDto)
        {
            try
            {
                IActionResult response = Unauthorized();

                var user = await _userService.Authenticate(userResultDto.UserEmail, userResultDto.Password);

                if (user == null)
                {
                    return BadRequest(new { message = "Email or password is incorrect" });
                }

                var tokenString = _userService.GenerateJWTToken(user);

                response = Ok(new
                {
                    Id = user.Id,
                    Email = user.UserEmail,
                    Role = user.UserRole,
                    Token = tokenString
                });

                return response;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserResultDto userResultDto)
        {
            // map dto to entity
            var user = _mapper.Map<UserModel>(userResultDto);

            try
            {
                IActionResult response = Unauthorized();

                // save 
                var userSave = await _userService.Create(user, userResultDto.Password);

                var tokenString = _userService.GenerateJWTToken(user);

                response = Ok(new
                {
                    Id = user.Id,
                    Email = user.UserEmail,
                    Role = user.UserRole,
                    Token = tokenString
                });

                return response;
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
