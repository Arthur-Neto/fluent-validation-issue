using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Teste
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Authenticate([FromBody] UserAuthenticateCommand command)
        {
            return Ok(command);
        }
    }

    public class UserAuthenticateCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserAuthenticateCommandValidator : AbstractValidator<UserAuthenticateCommand>
    {
        public UserAuthenticateCommandValidator()
        {
            RuleFor(x => x.Username).NotNull().Length(1, 50);
            RuleFor(x => x.Password).NotNull().Length(1, 50);
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

