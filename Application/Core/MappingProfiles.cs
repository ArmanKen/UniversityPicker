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
			CreateMap<University, UniversityDto>()
				.ForMember(x => x.Region, o => o.MapFrom(x => x.City.Region.Name))
				.ForMember(x => x.City, o => o.MapFrom(x => x.City.Name))
				.ForMember(x => x.Rating, o => o.MapFrom(x => (double)x.Rating / x.TimesRated))
				.ForMember(x => x.Specialty, o => o.MapFrom(x => x.Specialties));
			CreateMap<Specialty, SpecialtyDto>()
				.ForMember(x => x.Name, o => o.MapFrom(x => x.SpecialtyBase.Name))
				.ForMember(x => x.SpecialtyBaseId, o => o.MapFrom(x => x.SpecialtyBase.Id))
				.ForMember(x => x.Isceds, o => o.MapFrom(x => x.SpecialtyBase.Isceds));
			CreateMap<Isced, IscedDto>();
		}
	}
}