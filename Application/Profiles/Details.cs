using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles
{
	public class Details
	{
		public class Query : IRequest<Result<DTOs.Profile>>
		{
			public string Username { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<DTOs.Profile>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;
			private readonly IUserAccessor _userAccessor;

			public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
			{
				_userAccessor = userAccessor;
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<DTOs.Profile>> Handle(Query request, CancellationToken cancellationToken)
			{
				var user = await _context.Users
					.Include(x => x.University.Reviews)
					.Include(x => x.SpecialtyBase)
					.ProjectTo<DTOs.Profile>(_mapper.ConfigurationProvider)
					.FirstOrDefaultAsync(x => x.Username == request.Username);
				return Result<DTOs.Profile>.Success(user);
			}
		}
	}
}