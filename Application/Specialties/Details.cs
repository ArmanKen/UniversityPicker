using Application.Core;
using Application.DTOs;
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
			public Guid SpecialtyId { get; set; }
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
					.Include(x => x.EduComponents)
					.Include(x => x.Languages)
					.ProjectTo<SpecialtyDto>(_mapper.ConfigurationProvider)
					.FirstOrDefaultAsync(x => x.Id == request.SpecialtyId);
				if (specialty == null) return null;
				return Result<SpecialtyDto>.Success(specialty);
			}
		}
	}
}