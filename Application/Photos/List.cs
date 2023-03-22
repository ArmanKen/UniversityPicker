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
			public Guid InstitutionId { get; set; }
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
				var institution = await _context.Institutions
					.Include(x => x.Photos).FirstOrDefaultAsync(x => x.Id == request.InstitutionId);
				if (institution == null) return null;
				return Result<List<Photo>>.Success(institution.Photos.ToList());
			}
		}
	}
}