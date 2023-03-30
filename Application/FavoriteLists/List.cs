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
		public class Query : IRequest<Result<PagedList<UniversityDto>>>
		{
			public FavoriteListParams Params { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<PagedList<UniversityDto>>>
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

			public async Task<Result<PagedList<UniversityDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var observer = await _context.Users
					.Include(x => x.FavoriteList)
					.ThenInclude(x => x.University)
					.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
				return Result<PagedList<UniversityDto>>.Success(
					await PagedList<UniversityDto>.CreateAsync(
					observer.FavoriteList.AsQueryable()
						.ProjectTo<UniversityDto>(_mapper.ConfigurationProvider),
				request.Params.PageNumber, request.Params.PageSize));
			}
		}
	}
}