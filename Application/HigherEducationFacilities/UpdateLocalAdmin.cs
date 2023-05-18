using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.HigherEducationFacilities
{
	public class UpdateLocalAdmin
	{
		public class Command : IRequest<Result<Unit>>
		{
			public string Username { get; set; }
			public Guid HigherEducationFacilityId { get; set; }
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
				var higherEducationFacility = await _context.HigherEducationFacilities.FindAsync(request.HigherEducationFacilityId);
				if (higherEducationFacility == null) return null;
				var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.Username);
				if (user == null) return null;
				var localAdmin = await _context.HigherEducationFacilitesAdmins.FindAsync(higherEducationFacility.Id, user.Id);
				if (localAdmin == null)
					higherEducationFacility.HigherEducationFacilityAdmins.Add(new HigherEducationFacilityAdmin
					{
						AppUserId = user.Id,
						AppUser = user,
						HigherEducationFacilityId = higherEducationFacility.Id,
						HigherEducationFacility = higherEducationFacility
					});
				else _context.HigherEducationFacilitesAdmins.Remove(localAdmin);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to update the local admin");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}