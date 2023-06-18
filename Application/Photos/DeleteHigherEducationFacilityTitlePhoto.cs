using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Photos
{
	public class DeleteHigherEducationFacilityTitlePhoto
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Guid HigherEducationFacilityId { get; set; }
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
				var higherEducationFacility = await _context.HigherEducationFacilities
				.Include(x => x.Photos)
				.FirstOrDefaultAsync(x => x.Id == request.HigherEducationFacilityId);
				if (higherEducationFacility == null) return null;
				var photo = higherEducationFacility.Photos.FirstOrDefault(x => x.Url == higherEducationFacility.TitlePhoto);
				if (photo == null)
				{
					if (higherEducationFacility.TitlePhoto != "")
						higherEducationFacility.TitlePhoto = "";
					return null;
				}
				higherEducationFacility.Photos.Remove(photo);
				higherEducationFacility.TitlePhoto = "";
				var result = await _photoAccessor.DeletePhoto(photo.Id);
				if (result == null) return Result<Unit>.Failure("Problem deleting photo from Cloudinary");
				var success = await _context.SaveChangesAsync() > 0;
				if (success) return Result<Unit>.Success(Unit.Value);
				return Result<Unit>.Failure("Problem deleting photo from API");
			}
		}
	}
}