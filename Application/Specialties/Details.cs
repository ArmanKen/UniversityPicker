using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Specialties
{
	public class Details
	{
		public class Query : IRequest<Result<SpecialtyDto>>
		{
			public Guid Id { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<SpecialtyDto>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<SpecialtyDto>> Handle(Query request, CancellationToken cancellationToken)
			{
				var specialty = await _context.Specialties
					.ProjectTo<SpecialtyDto>(_mapper.ConfigurationProvider)
					.FirstOrDefaultAsync(x => x.Id == request.Id);
				return Result<SpecialtyDto>.Success(specialty);
			}
		}
	}
}