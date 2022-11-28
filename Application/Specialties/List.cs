using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Specialties
{
	public class List
	{
		public class Query : IRequest<Result<List<Specialty>>> { }

		public class Handler : IRequestHandler<Query, Result<List<Specialty>>>
		{
			private readonly DataContext _context;

			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<Result<List<Specialty>>> Handle(Query request, CancellationToken cancellationToken)
			{
				var specialties = await _context.Specialties.ToListAsync();
				return Result<List<Specialty>>.Success(specialties);
			}
		}
	}
}