using Application.Core;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.EduComponents
{
	public class List
	{
		public class Query : IRequest<Result<List<EduComponentDto>>>
		{
			public Guid SpecialtyId { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<List<EduComponentDto>>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<List<EduComponentDto>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var specialty = await _context.Specialties.FindAsync(request.SpecialtyId);
				if (specialty == null) return null;
				var educationComponents = _mapper.Map<List<EduComponentDto>>(specialty.EduComponents);
				if (educationComponents == null) return null;
				return Result<List<EduComponentDto>>.Success(educationComponents);
			}
		}
	}
}