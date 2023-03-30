using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Universities
{
	public class UpdateLocalAdmin
	{
		public class Command : IRequest<Result<Unit>>
		{
			public string Username { get; set; }
			public Guid UniversityId { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_mapper = mapper;
				_context = context;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				var university = await _context.Universities.FindAsync(request.UniversityId);
				if (university == null) return null;
				var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.Username);
				if (user == null) return null;
				var localAdmin = await _context.UniversitiesAdmins.FindAsync(university.Id, user.Id);
				if (localAdmin == null)
					university.UniversityAdmins.Add(new UniversityAdmin
					{
						AppUserId = user.Id,
						AppUser = user,
						UniversityId = university.Id,
						University = university
					});
				else _context.UniversitiesAdmins.Remove(localAdmin);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to update the local admin");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}