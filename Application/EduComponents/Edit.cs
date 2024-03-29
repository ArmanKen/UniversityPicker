using Application.Core;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.EduComponents
{
	public class Edit
	{
		public class Command : IRequest<Result<Unit>>
		{
			public EduComponentDto EducationComponent { get; set; }
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
				var educationComponent = await _context.EduComponents.FindAsync(request.EducationComponent.Id);
				if (educationComponent == null) return null;
				_mapper.Map(request.EducationComponent, educationComponent);
				var result = await _context.SaveChangesAsync() > 0;
				if (!result) return Result<Unit>.Failure("Failed to update the specialty");
				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}