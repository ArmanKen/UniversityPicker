using Application.Disciplines;
using Application.Region;
using Application.Specialties;
using Application.SpecialtiesBases;
using Application.Universities;
using AutoMapper;
using Domain;

namespace Application.Core
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			string specialtyId = null;
			string degree = null;
			string specialtyBaseId = null;
			CreateMap<University, University>();
			CreateMap<Specialty, Specialty>();
			CreateMap<Discipline, Discipline>();
			CreateMap<University, UniversityDto>()
				.ForMember(u => u.Specialty, o => o.MapFrom(u =>
					degree == "Bachelor" ? u.BachelorSpecialties.FirstOrDefault(s => s.Specialty.SpecialtyBase.Id == specialtyBaseId).Specialty :
					degree == "JunBachelor" ? u.JunBachelorSpecialties.FirstOrDefault(s => s.Specialty.SpecialtyBase.Id == specialtyBaseId).Specialty :
					degree == "Magister" ? u.MagisterSpecialties.FirstOrDefault(s => s.Specialty.SpecialtyBase.Id == specialtyBaseId).Specialty :
					null))
				.ForMember(u => u.Region, o => o.MapFrom(u => u.City.Region.Name))
				.ForMember(u => u.City, o => o.MapFrom(u => u.City.Name));
			CreateMap<Specialty, SpecialtyDto>()
				.ForMember(s => s.SpecialtyBaseId, o => o.MapFrom(s => s.SpecialtyBase.Id))
				.ForMember(s => s.Name, o => o.MapFrom(s => s.SpecialtyBase.Name))
				.ForMember(s => s.ISCEDs, o => o.MapFrom(s => s.SpecialtyBase.ISCEDs));
			CreateMap<Discipline, DisciplineDto>()
				.ForMember(d => d.IsOptional, o => o.MapFrom(d => d.Specialties
					.FirstOrDefault(x => x.SpecialtyId.ToString() == specialtyId).IsOptional));
			CreateMap<Domain.Region, RegionDto>();
			CreateMap<Domain.City, CityDto>();
		}
	}
}