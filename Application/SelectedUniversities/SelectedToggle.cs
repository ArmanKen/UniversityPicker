using Application.Core;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.SelectedUniversities
{
	public class SelectedToggle
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Guid TargetUniversityId { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly DataContext _context;
			private readonly IUserAccessor _userAccessor;
			public Handler(DataContext context, IUserAccessor userAccessor)
			{
				_userAccessor = userAccessor;
				_context = context;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				var observer = await _context.Users.FirstOrDefaultAsync(x =>
					x.UserName == _userAccessor.GetUsername());
				var university = await _context.Universities.FirstOrDefaultAsync(x => x.Id == request.TargetUniversityId);
				if (university == null) return null;
				var selected = await _context.SelectedUniversities.FindAsync(observer!.Id, university.Id);
				if (selected == null)
				{
					selected = new SelectedUniversity
					{
						AppUser = observer,
						University = university
					};
					_context.SelectedUniversities.Add(selected);
				}
				else _context.SelectedUniversities.Remove(selected);
				var success = await _context.SaveChangesAsync() > 0;
				if (success) return Result<Unit>.Success(Unit.Value);
				return Result<Unit>.Failure("Failed to update selected");
			}
		}
	}
}