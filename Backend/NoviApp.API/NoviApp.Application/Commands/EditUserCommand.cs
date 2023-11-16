using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NoviApp.Application.Dtos.Users;
using NoviApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoviApp.Application.Commands
{
    public class EditUserCommand: IRequest<UserDto>
    {
        public int IdUser { get; set; }
        public string UserName1 { get; set; } = null!;
        public string? UserName2 { get; set; }
        public string UserLastName1 { get; set; } = null!;
        public string? UserLastName2 { get; set; }
        public string? Email { get; set; } = null!;
        public string? UserPassword { get; set; } = null!;
        public string? PhoneNumber { get; set; }
    }

    public class EditUserCommandHandler: IRequestHandler<EditUserCommand, UserDto>
    {
        private readonly ILogger<EditUserCommandHandler> _logger;
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EditUserCommandHandler(ILogger<EditUserCommandHandler> logger, IApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(EditUserCommand command, CancellationToken cancellationToken)
        {
            _logger.LogDebug("EditUserCommandHandler STARTED");
            var request = await _context.Users.FirstOrDefaultAsync
                (x => x.IdUser == command.IdUser, cancellationToken);
            if (request == null)
            {
                throw new InvalidOperationException("No encontrado");
            }

            _mapper.Map(command, request);

            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogDebug("EditUserCommandHandler FINISHED");

            return _mapper.Map<UserDto>(command);
        }
    }
}
