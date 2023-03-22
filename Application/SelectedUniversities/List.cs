using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using Application.Institutions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.FavoriteLists
{
	public class List
	{
		public class Query : IRequest<Result<List<InstitutionDto>>>
		{

		}

		public class Handler : IRequestHandler<Query, Result<List<InstitutionDto>>>
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

			public async Task<Result<List<InstitutionDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				// var observer = await _context.Users
				// 	// .Include(x => x.FavoriteLists)
				// 	// .ThenInclude(x => x.Institution)
				// 	.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
				// return Result<List<InstitutionDto>>.Success(
				// 	observer.FavoriteLists
				// 		.AsQueryable()
				// 		.ProjectTo<InstitutionDto>(_mapper.ConfigurationProvider)
				// 		.ToList());
				return Result<List<InstitutionDto>>.Failure("lol");
			}
		}
	}
}