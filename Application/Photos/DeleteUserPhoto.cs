using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Photos
{
	public class DeleteUserPhoto
	{
		public class Command : IRequest<Result<Unit>>
		{
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly DataContext _context;
			private readonly IPhotoAccessor _photoAccessor;
			private readonly IUserAccessor _userAccessor;

			public Handler(DataContext context, IPhotoAccessor photoAccessor, IUserAccessor userAccessor)
			{
				_userAccessor = userAccessor;
				_photoAccessor = photoAccessor;
				_context = context;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				var user = await _context.Users.Include(p => p.Photo)
					.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
				if (user == null) return null;
				var photo = user.Photo;
				if (photo == null) return null;
				var result = await _photoAccessor.DeletePhoto(photo.Id);
				_context.Photos.Remove(photo);
				if (result == null) return Result<Unit>.Failure("Problem deleting photo from Cloudinary");
				user.Photo = new Domain.Photo();
				var success = await _context.SaveChangesAsync() > 0;
				if (success) return Result<Unit>.Success(Unit.Value);
				return Result<Unit>.Failure("Problem deleting photo from API");
			}
		}
	}
}