using Application.Core;
using Application.Interfaces;
using MediatR;
using Persistence;

namespace Application.Photos
{
	public class DeleteUniversityTitlePhoto
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Guid UniversityId { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly DataContext _context;
			private readonly IPhotoAccessor _photoAccessor;

			public Handler(DataContext context, IPhotoAccessor photoAccessor)
			{
				_photoAccessor = photoAccessor;
				_context = context;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				var university = await _context.Universities.FindAsync(request.UniversityId);
				if (university == null) return null;
				var photo = university.Photos.FirstOrDefault(x => x.Url == university.TitlePhoto);
				if (photo == null) return null;
				university.TitlePhoto = "";
				var result = await _photoAccessor.DeletePhoto(photo.Id);
				if (result == null) return Result<Unit>.Failure("Problem deleting photo from Cloudinary");
				var success = await _context.SaveChangesAsync() > 0;
				if (success) return Result<Unit>.Success(Unit.Value);
				return Result<Unit>.Failure("Problem deleting photo from API");
			}
		}
	}
}