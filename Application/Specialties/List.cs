using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
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
				var specialties = await _context.Specialties.Where(x => x.University.Id == request.Id)
															.ProjectTo<SpecialtyDto>(_mapper.ConfigurationProvider)
															.ToListAsync();
				if (specialties == null) return null;
				return Result<List<SpecialtyDto>>
					.Success(specialties);
			}
		}
	}
}