using Application.Core;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Photos
{
	public class AddHigherEducationFacilityPhoto
	{
		public class Command : IRequest<Result<Photo>>
		{
			public IFormFile File { get; set; }
			public Guid HigherEducationFacilityId { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<Photo>>
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

			public async Task<Result<Photo>> Handle(Command request, CancellationToken cancellationToken)
			{
				var higherEducationFacility = await _context.HigherEducationFacilities
					.FirstOrDefaultAsync(x => x.Id == request.HigherEducationFacilityId);
				if (higherEducationFacility == null) return null;
				var photoUploadResult = await _photoAccessor.AddPhoto(request.File);
				var photo = new Photo
				{
					Url = photoUploadResult.Url,
					Id = photoUploadResult.PublicId
				};
				higherEducationFacility.Photos.Add(photo);
				var result = await _context.SaveChangesAsync() > 0;
				if (result) return Result<Photo>.Success(photo);
				return Result<Photo>.Failure("Problem when adding photo");
			}
		}
	}
}