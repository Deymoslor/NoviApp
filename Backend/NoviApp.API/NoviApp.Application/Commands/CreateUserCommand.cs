using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NoviApp.Application.Dtos.Users;
using NoviApp.Application.Interfaces;
using NoviApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoviApp.Application.Commands
{
    public class CreateUserCommand: IRequest<UserDto>
    {

        public string UserName1 { get; set; } = null!;
        public string? UserName2 { get; set; }
        public string UserLastName1 { get; set; } = null!;
        public string? UserLastName2 { get; set; }
        public string? Email { get; set; } = null!;
        public string? UserPassword { get; set; } = null!;
        public string? PhoneNumber { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger, IApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            _logger.LogDebug("CreateUserCommandHandler STARTED");
            var request = _mapper.Map<User>(command);

            await _context.Users.AddAsync(request);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogDebug("CreateUserCommandHandler FINISHED");

            return _mapper.Map<UserDto>(command);
        }

    }
}
