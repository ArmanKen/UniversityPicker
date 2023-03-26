using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using Application.Universities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.FavoriteLists
{
	public class List
	{
		public class Query : IRequest<Result<List<UniversityDto>>>
		{

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
				// var observer = await _context.Users
				// 	// .Include(x => x.FavoriteLists)
				// 	// .ThenInclude(x => x.University)
				// 	.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
				// return Result<List<UniversityDto>>.Success(
				// 	observer.FavoriteLists
				// 		.AsQueryable()
				// 		.ProjectTo<UniversityDto>(_mapper.ConfigurationProvider)
				// 		.ToList());
				return Result<List<UniversityDto>>.Failure("lol");
			}
		}
	}
}