using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Institutions
{
	public class ToggleLocalAdministrator
	{
		public class Command : IRequest<Result<Unit>>
		{
			public string Username { get; set; }
			public Guid Id { get; set; }
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
				var institution = await _context.Institutions.FindAsync(request.Id);
				if (institution == null) return null;
				var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.Username);
				if (user == null) return null;
				var localAdmin = await _context.InstitutionsAdmins.FindAsync(institution.Id, user.Id);
				if (localAdmin == null)
					institution.InstitutionAdmins.Add(new InstitutionAdmin
					{
						AppUserId = user.Id,
						AppUser = user,
						InstitutionId = institution.Id,
						Institution = institution
					});
				else _context.InstitutionsAdmins.Remove(localAdmin);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to update the local admin");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}