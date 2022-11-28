using Application.Disciplines;
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
				.ForMember(d => d.Disciplines, o => o.MapFrom(s => s.Disciplines));
			CreateMap<SpecialtieDisciplines, DisciplineDto>()
				.ForMember(d => d.Id, o => o.MapFrom(s => s.Discipline!.Id))
				.ForMember(d => d.Name, o => o.MapFrom(s => s.Discipline!.Name));

			CreateMap<University, UniversityDto>()
				.ForMember(d => d.Specialties, o => o.MapFrom(s => s.Specialties));
			CreateMap<UniversitySpecialties, SpecialtyDto>()
				.ForMember(d => d.Id, o => o.MapFrom(s => s.Specialty!.Id))
				.ForMember(d => d.Code, o => o.MapFrom(s => s.Specialty!.Code))
				.ForMember(d => d.BranchOfKnowledge, o => o.MapFrom(s => s.Specialty!.BranchOfKnowledge!.BranchOfKnowledge!.Name))
				.ForMember(d => d.Disciplines, o => o.MapFrom(s => s.Specialty!.Disciplines))
				.ForMember(d => d.Code, o => o.MapFrom(s => s.Specialty!.Code))
				.ForMember(d => d.Name, o => o.MapFrom(s => s.Specialty!.Name));
		}
	}
}