using Application.Core;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Photos
{
	public class AddInstitutionTitlePhoto
	{
		public class Command : IRequest<Result<Photo>>
		{
			public IFormFile File { get; set; }
			public Guid InstitutionId { get; set; }
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
				var institution = await _context.Institutions.Include(p => p.Photos)
					.FirstOrDefaultAsync(x => x.Id == request.InstitutionId);
				if (institution == null) return null!;
				var photoUploadResult = await _photoAccessor.AddPhoto(request.File!);
				var photo = new Photo
				{
					Url = photoUploadResult.Url,
					Id = photoUploadResult.PublicId
				};
				if (institution.TitlePhoto != null && !string.IsNullOrEmpty(institution.TitlePhoto.Id))
					await _photoAccessor.DeletePhoto(institution.TitlePhoto.Id);
				institution.TitlePhoto = photo;
				var result = await _context.SaveChangesAsync() > 0;
				if (result) return Result<Photo>.Success(photo);
				return Result<Photo>.Failure("Problem when adding photo");
			}
		}
	}
}