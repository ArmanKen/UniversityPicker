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
				.ForMember(d => d.Name, o => o.MapFrom(s => s.Discipline!.Name))
				.ForMember(d => d.Info, o => o.MapFrom(s => s.Discipline!.Info));

			CreateMap<University, UniversityDto>()
				.ForMember(d => d.Specialties, o => o.MapFrom(s => s.Specialties));
			CreateMap<UniversitySpecialties, SpecialtyDto>()
				.ForMember(d => d.Id, o => o.MapFrom(s => s.Specialty!.Id))
				.ForMember(d => d.Code, o => o.MapFrom(s => s.Specialty!.Code))
				.ForMember(d => d.Price, o => o.MapFrom(s => s.Specialty!.Price))
				.ForMember(d => d.Info, o => o.MapFrom(s => s.Specialty!.Info))
				.ForMember(d => d.Disciplines, o => o.MapFrom(s => s.Specialty!.Disciplines));
		}
	}
}