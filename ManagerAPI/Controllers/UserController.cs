using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using ManagerAPI.Utilities;
using ManagerAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Controllers
{
    [ApiController]    
    
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                var userDto = _mapper.Map<UserDTO>(userViewModel);

                var userCreated = await _userService.Create(userDto);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com sucesso.",
                    Success = true,
                    Data = userCreated
                });


            }
            catch(DomainException exception)
            {
                return BadRequest(Responses.DomainErrorMessage(exception.Message, exception.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}


