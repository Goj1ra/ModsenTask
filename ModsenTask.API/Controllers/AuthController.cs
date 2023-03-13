using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ModsenTask.API.Mapper;
using ModsenTask.API.ViewModels;
using ModsenTask.Business.Mapper;
using ModsenTask.Business.Models;
using ModsenTask.Business.Services;
using ModsenTask.Business.Services.Interfaces;
using ModsenTask.Data.Entities;
using System.Text.Json;

namespace ModsenTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [Route("~/api/Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserViewModel userViewModel)
        {
            try
            {
                var user = ApiMapper.Mapper.Map<UserModel>(userViewModel);
                var response = await _userService.Login(user);
                var apiResult = ApiResult<UserModel>.Success(response);
                return Ok(apiResult);
            }
            catch (Exception ex)
            {
                var apiResult = ApiResult<UserModel>.Failure(new[] { ex.Message });
                return Problem(detail: JsonSerializer.Serialize(apiResult));
            }
        }

        [AllowAnonymous]
        [Route("~/api/Register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserViewModel userViewModel)
        {

            try
            {
                var user = ApiMapper.Mapper.Map<UserModel>(userViewModel);
                var response = await _userService.Register(user);
                var apiResult = ApiResult<UserModel>.Success(response);
                return Ok(apiResult);
            }
            catch (Exception ex)
            {
                var apiResult = ApiResult<UserModel>.Failure(new[] { ex.Message });
                return Problem(detail: JsonSerializer.Serialize(apiResult));
            }
        }
    }
}
