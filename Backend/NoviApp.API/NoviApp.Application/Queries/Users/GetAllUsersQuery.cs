using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
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
    public class getAllUsersQuery : IRequest<List<UserDto>>
    {

    }

    public class getAllUsersQueryHandler: IRequestHandler<getAllUsersQuery, List<UserDto>> 
    {
        private readonly ILogger<getAllUsersQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public getAllUsersQueryHandler(IApplicationDbContext context, ILogger<getAllUsersQueryHandler> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(getAllUsersQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("getAllUsersQueryHandler STARTED");
            var query = await _context.Users
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var userDto = _mapper.Map<List<UserDto>>(query);

            _logger.LogDebug("getAllUsersQueryHandler FINISHED");
            return userDto;
        }
    }

    
    
}
