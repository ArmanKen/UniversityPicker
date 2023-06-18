using Application.Core;
using Application.DTOs;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.HigherEducationFacilities
{
	public class Create
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
				_context.HigherEducationFacilities.Add(new HigherEducationFacility
				{
					Name = request.HigherEducationFacility.Name,
					Address = request.HigherEducationFacility.Address,
					Website = request.HigherEducationFacility.Website,
					Info = request.HigherEducationFacility.Info,
					Telephone = request.HigherEducationFacility.Telephone,
					UkraineTop = request.HigherEducationFacility.UkraineTop,
					Accreditation = await _context.Accreditations.FindAsync(request.HigherEducationFacility.Accreditation),
					Region = await _context.Regions.FindAsync(request.HigherEducationFacility.Region),
					City = await _context.Cities.FindAsync(request.HigherEducationFacility.City)
				});
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to create higherEducationFacility");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}