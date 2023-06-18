using Application.Core;
using Application.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.HigherEducationFacilities
{
	public class Edit
	{
		public class Command : IRequest<Result<Unit>>
		{
			public HigherEducationFacilityFormValues HigherEducationFacility { get; set; }
		}

		public class CommandValidator : AbstractValidator<Command>
		{
			public CommandValidator()
			{
				RuleFor(x => x.HigherEducationFacility.Id);
				RuleFor(x => x.HigherEducationFacility.Name);
			}
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
				var higherEducationFacility = await _context.HigherEducationFacilities.FindAsync(request.HigherEducationFacility.Id);
				if (higherEducationFacility == null) return Result<Unit>.Failure("Failed to update the higherEducationFacility");
				higherEducationFacility.Name = request.HigherEducationFacility.Name;
				higherEducationFacility.Address = request.HigherEducationFacility.Address;
				higherEducationFacility.Website = request.HigherEducationFacility.Website;
				higherEducationFacility.Info = request.HigherEducationFacility.Info;
				higherEducationFacility.Telephone = request.HigherEducationFacility.Telephone;
				higherEducationFacility.UkraineTop = request.HigherEducationFacility.UkraineTop;
				higherEducationFacility.Location = request.HigherEducationFacility.LocationLat != default &&
						request.HigherEducationFacility.LocationLong != default ?
							new Domain.Location
							{
								Latitude = request.HigherEducationFacility.LocationLat,
								Longitude = request.HigherEducationFacility.LocationLong
							} : default;
				higherEducationFacility.Accreditation = await _context.Accreditations.FindAsync(request.HigherEducationFacility.Accreditation);
				higherEducationFacility.Region = await _context.Regions.FindAsync(request.HigherEducationFacility.Region);
				higherEducationFacility.City = await _context.Cities.FindAsync(request.HigherEducationFacility.City);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to update the higherEducationFacility");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}