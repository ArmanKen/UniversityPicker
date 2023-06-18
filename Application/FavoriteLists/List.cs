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
				var favoriteList = _context.FavoriteLists
					.Include(x => x.HigherEducationFacility)
					.ThenInclude(x=>x.Region)
					.Include(x => x.HigherEducationFacility)
					.ThenInclude(x => x.City)
					.Include(x => x.HigherEducationFacility)
					.ThenInclude(x => x.Accreditation)
					.Include(x => x.HigherEducationFacility)
					.ThenInclude(x => x.Location)
					.Include(x => x.HigherEducationFacility)
					.ThenInclude(x => x.Photos)
					.Include(x => x.HigherEducationFacility)
					.ThenInclude(x => x.Faculties)
					.Include(x => x.HigherEducationFacility)
					.ThenInclude(x => x.Reviews)
					.Include(x => x.HigherEducationFacility)
					.ThenInclude(x => x.HigherEducationFacilityAdmins)
					.Include(x => x.HigherEducationFacility)
					.ThenInclude(x => x.FavoriteList)
					.Where(x => x.AppUser.UserName == _userAccessor.GetUsername()).ProjectTo<HigherEducationFacilityDto>(_mapper.ConfigurationProvider,
						new { username = _userAccessor.GetUsername() });
				var list = favoriteList;
				return Result<PagedList<HigherEducationFacilityDto>>.Success(
					await PagedList<HigherEducationFacilityDto>.CreateAsync(
					list,
				request.Params.PageNumber, request.Params.PageSize));
			}
		}
	}
}