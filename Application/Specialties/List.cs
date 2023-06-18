using Application.Core;
using Application.DTOs;
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
			public Guid FacultyId { get; set; }
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
				var specialties = _context.Specialties
					.Include(x => x.SpecialtyBase.Isceds)
					.Include(x => x.StudyForms)
					.Include(x => x.Degree)
					.Where(x => x.Faculty.Id == request.FacultyId);
				if (specialties == null) return null;
				return Result<List<SpecialtyDto>>.Success(
					await specialties
					.ProjectTo<SpecialtyDto>(_mapper.ConfigurationProvider)
					.ToListAsync());
			}
		}
	}
}