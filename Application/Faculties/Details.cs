using Application.Core;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Faculties
{
	public class Details
	{
		public class Query : IRequest<Result<FacultyDto>>
		{
			public Guid FacultyId { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<FacultyDto>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<FacultyDto>> Handle(Query request, CancellationToken cancellationToken)
			{
				var faculty = await _context.Faculties
					.ProjectTo<FacultyDto>(_mapper.ConfigurationProvider)
					.FirstOrDefaultAsync(x => x.Id == request.FacultyId);
				if (faculty == null) return null;
				return Result<FacultyDto>.Success(faculty);
			}
		}
	}
}