using Application.Core;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Faculties
{
	public class List
	{
		public class Query : IRequest<Result<List<FacultyDto>>>
		{
			public Guid UniversityId { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<List<FacultyDto>>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<List<FacultyDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var university = await _context.Universities
					.Include(x => x.Faculties)
					.ThenInclude(x => x.FacultyPhoto)
					.Include(x => x.Faculties)
					.ThenInclude(x => x.KnowledgeBranches)
					.FirstOrDefaultAsync(x => x.Id == request.UniversityId);
				if (university == null) return null;
				return Result<List<FacultyDto>>.Success(
					university.Faculties
						.AsQueryable()
						.ProjectTo<FacultyDto>(_mapper.ConfigurationProvider)
						.ToList());
			}
		}
	}
}