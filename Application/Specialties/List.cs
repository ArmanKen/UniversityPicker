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
			public Guid Id { get; set; }
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
				var university = await _context.Universities
					.Include(x => x.Specialties)
					.ThenInclude(x => x.SpecialtyBase.Isceds)
					.FirstOrDefaultAsync(x => x.Id == request.Id);
				if(university == null) return null;
				var specialties = university.Specialties
					.AsQueryable()
					.ProjectTo<SpecialtyDto>(_mapper.ConfigurationProvider)
					.ToList();
				if (specialties == null) return null;
				return Result<List<SpecialtyDto>>
					.Success(specialties);
			}
		}
	}
}