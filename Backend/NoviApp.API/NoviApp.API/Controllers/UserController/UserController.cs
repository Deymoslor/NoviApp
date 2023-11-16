using NoviApp.Application.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoviApp.Application.Commands;

namespace NoviApp.API.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsersQuery ()
        {
            try
            {
                var result = await _mediator.Send(new getAllUsersQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: ", ex);
            }
        }

        [HttpGet]
        [Route("GetAllByIdUser/{id}")]
        public async Task<IActionResult> GetAllByIdUserQuery (int id)
        {
            try
            {
                var result = await _mediator.Send(new GetAllByIdUserQuery { idUser = id });
                if (result == null)
                {
                    return NotFound();
                }
                else { return Ok(result); }
            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUserCommand (CreateUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result); 
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
        }

        [HttpPut]
        [Route("EditUserById")]
        public async Task<IActionResult> EditUserCommand(EditUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if(result == null)
                {
                    return NotFound();
                }
                else { return Ok(result); }
            }
            catch (Exception ex)
            {

                throw new Exception("Error: ", ex);
            }
        }
    }
}
