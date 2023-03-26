using Application.Core;
using Application.DTOs;
using AutoMapper;
using MediatR;
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
					.FindAsync(request.FacultyId);
				if (faculty == null) return null;
				return Result<FacultyDto>.Success(_mapper.Map<FacultyDto>(faculty));
			}
		}
	}
}