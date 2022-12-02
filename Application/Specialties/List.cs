using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Specialties
{
	public class List
	{
		public class Query : IRequest<Result<List<SpecialtyDto>>> { }

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
				var specialties = await _context.Specialties
				.Include(s => s.Disciplines)
				.ThenInclude(d => d.Discipline)
				.ToListAsync();
				var specialtiesToReturn = _mapper.Map<List<SpecialtyDto>>(specialties);
				return Result<List<SpecialtyDto>>.Success(specialtiesToReturn);
			}
		}
	}
}