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

namespace NoviApp.Application.Queries.Users
{
    public class GetAllByIdUserQuery: IRequest<UserDto>
    {
        public int idUser { get; set; }
    }

    public class GetByIdUserQueryHandler: IRequestHandler<GetAllByIdUserQuery, UserDto>
    {
        private readonly ILogger<GetByIdUserQueryHandler> _logger;
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetByIdUserQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetByIdUserQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;   
        }

        public async Task<UserDto> Handle(GetAllByIdUserQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("GetByIdUserQueryHandler STARTED");
            var query = await _context.Users.FirstOrDefaultAsync(x => x.IdUser == request.idUser, cancellationToken);

            var userDto = _mapper.Map<UserDto>(query);

            _logger.LogDebug("GetByIdUserQueryHandler FINISHED");
            return userDto;
        }
    }
}
