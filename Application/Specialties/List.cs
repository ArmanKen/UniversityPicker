using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Specialties
{
	public class List
	{
		public class Query : IRequest<Result<List<SpecialtyDto>>>
		{
			public string UniversityId { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<List<SpecialtyDto>>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<List<SpecialtyDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var university = _context.Universities.FindAsync(request.UniversityId).Result;
				if (university == null) return null;
				var specialties = university.Specialties
					.AsQueryable()
					.ProjectTo<SpecialtyDto>(_mapper.ConfigurationProvider);
				return Result<List<SpecialtyDto>>.Success(await specialties.ToListAsync());
			}
		}
	}
}