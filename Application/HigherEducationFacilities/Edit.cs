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
			public HigherEducationFacilityDto HigherEducationFacility { get; set; }
		}

		public class CommandValidator : AbstractValidator<Command>
		{
			public CommandValidator()
			{
				RuleFor(x => x.HigherEducationFacility).SetValidator(new HigherEducationFacilityValidator());
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
				_mapper.Map(request.HigherEducationFacility, higherEducationFacility);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to update the higherEducationFacility");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}