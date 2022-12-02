using Application.BranchesOfKnowledge;
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
				.ForMember(d => d.Disciplines, o => o.MapFrom(s => s.Disciplines));
			CreateMap<SpecialtyDisciplines, DisciplineDto>()
				.ForMember(d => d.Id, o => o.MapFrom(s => s.Discipline!.Id))
				.ForMember(d => d.Name, o => o.MapFrom(s => s.Discipline!.Name));
			CreateMap<BranchOfKnowledge, BranchOfKnowledgeDto>()
				.ForMember(d => d.Specialties, o => o.MapFrom(s => s.Specialties));
			CreateMap<BranchOfKnowledgeSpecialties, SpecialtyDto>()
				.ForMember(d => d.Id, o => o.MapFrom(s => s.Specialty!.Id))
				.ForMember(d => d.Name, o => o.MapFrom(s => s.Specialty!.Name))
				.ForMember(d => d.Code, o => o.MapFrom(s => s.Specialty!.Code))
				.ForMember(d => d.Disciplines, o => o.MapFrom(s => s.Specialty!.Disciplines));
			CreateMap<University, UniversityDto>()
				.ForMember(d => d.BranchesOfKnowledge, o => o.MapFrom(s => s.BranchesOfKnowledge));
			CreateMap<UniversityBranchesOfKnowledge, BranchOfKnowledgeDto>()
				.ForMember(d => d.Id, o => o.MapFrom(s => s.BranchOfKnowledge!.Id))
				.ForMember(d => d.Name, o => o.MapFrom(s => s.BranchOfKnowledge!.Name))
				.ForMember(d => d.Specialties, o => o.MapFrom(s => s.BranchOfKnowledge!.Specialties));
		}
	}
}