using Application.Specialties;
using Application.Universities;
using AutoMapper;
using Domain;

namespace Application.Core
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Specialty, SpecialtyDto>()
				.ForMember(d => d.BranchOfKnowledge, o => o.MapFrom(s => s.BranchOfKnowledge!.BranchOfKnowledge!.Name))
				.ForMember(d=>d.Disciplines,o=>o.MapFrom(s => s.Disciplines));
			CreateMap<University, UniversityDto>()
				.ForMember(d => d.Specialties, o => o.MapFrom(s => s.Specialties));
			CreateMap<UniversitySpecialties, SpecialtyDto>()
				.ForMember(d => d.Name, o => o.MapFrom(s => s.Specialty!.Name));
		}
	}
}