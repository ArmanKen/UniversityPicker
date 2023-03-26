using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Photos
{
	public class List
	{
		public class Query : IRequest<Result<List<Photo>>>
		{
			public Guid UniversityId { get; set; }
		}

		public class Handler : IRequestHandler<Query, Result<List<Photo>>>
		{
			private readonly DataContext _context;

			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<Result<List<Photo>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var university = await _context.Universities
					.Include(x => x.Photos).FirstOrDefaultAsync(x => x.Id == request.UniversityId);
				if (university == null) return null;
				return Result<List<Photo>>.Success(university.Photos.ToList());
			}
		}
	}
}