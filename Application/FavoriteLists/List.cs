using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.FavoriteLists
{
	public class List
	{
		public class Query : IRequest<Result<PagedList<HigherEducationFacilityDto>>>
		{
			public FavoriteListParams Params { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<PagedList<HigherEducationFacilityDto>>>
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

			public async Task<Result<PagedList<HigherEducationFacilityDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var observer = await _context.Users
					.Include(x => x.FavoriteList)
					.ThenInclude(x => x.HigherEducationFacility)
					.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
				return Result<PagedList<HigherEducationFacilityDto>>.Success(
					await PagedList<HigherEducationFacilityDto>.CreateAsync(
					observer.FavoriteList.AsQueryable()
						.ProjectTo<HigherEducationFacilityDto>(_mapper.ConfigurationProvider, new { username = _userAccessor.GetUsername() }),
				request.Params.PageNumber, request.Params.PageSize));
			}
		}
	}
}