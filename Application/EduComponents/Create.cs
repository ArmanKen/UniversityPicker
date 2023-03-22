using Application.Core;
using Application.DTOs;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.EduComponents
{
	public class Create
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Guid SpecialtyId { get; set; }
			public EduComponentDto EducationComponent { get; set; }
		}

		public class CommandValidator : AbstractValidator<Command>
		{
			public CommandValidator()
			{
				RuleFor(x => x.EducationComponent).SetValidator(new EducationComponentValidator()); //REDO
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
				var specialty = _context.Specialties.FindAsync(request.SpecialtyId).Result;
				if (specialty == null) return Result<Unit>.Failure("Failed to create discipline");
				var educationComponent = _mapper.Map<EduComponent>(request.EducationComponent);
				specialty.EduComponents.Add(educationComponent);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to create Education Component");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}