using Application.Core;
using Application.Interfaces;
using Application.Universities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.SelectedUniversities
{
	public class List
	{
		public class Query : IRequest<Result<List<UniversityDto>>>
		{
			public string Username { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<List<UniversityDto>>>
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

			public async Task<Result<List<UniversityDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var universitites = await _context.SelectedUniversities.Where(x => x.AppUser.UserName == request.Username)
				.Select(u => u.University)
				.ProjectTo<UniversityDto>(_mapper.ConfigurationProvider, new { currentUsername = _userAccessor.GetUsername() })
				.ToListAsync();
				return Result<List<UniversityDto>>.Success(universitites);
			}
		}
	}
}