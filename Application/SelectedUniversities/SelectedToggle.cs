using Application.Core;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.FavoriteLists
{
	public class SelectedToggle
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Guid TargetInstitutionId { get; set; }
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
				var institution = await _context.Institutions.FirstOrDefaultAsync(x => x.Id == request.TargetInstitutionId);
				if (institution == null) return null;
				var selected = await _context.FavoriteLists.FindAsync(observer!.Id, institution.Id);
				if (selected == null)
					_context.FavoriteLists.Add(new FavoriteList
					{
						AppUser = observer,
						Institution = institution
					});
				else _context.FavoriteLists.Remove(selected);
				var success = await _context.SaveChangesAsync() > 0;
				if (success) return Result<Unit>.Success(Unit.Value);
				return Result<Unit>.Failure("Failed to update selected");
			}
		}
	}
}