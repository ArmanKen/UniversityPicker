using Application.DTOs;
using AutoMapper;
using Domain;

namespace Application.Core
{
	public class MappingProfiles : AutoMapper.Profile
	{
		public MappingProfiles()
		{
			string[] SpecialtyBaseId = null;
			CreateMap<University, UniversityDto>()
				.ForMember(x => x.Region, o => o.MapFrom(x => x.City.Region.Name))
				.ForMember(x => x.City, o => o.MapFrom(x => x.City.Name))
				.ForMember(x => x.Rating, o => o.MapFrom(x => x.Comments.Count() > 0 ? x.Comments.Average(x => x.Rating) : 0))
				.ForMember(x => x.PriceUAH, o => o.MapFrom(x => SpecialtyBaseId.Length == 1 && !string.IsNullOrEmpty(SpecialtyBaseId[0]) ?
					x.Specialties.FirstOrDefault(x => x.SpecialtyBase.Id == SpecialtyBaseId[0]).PriceUAH : 0));
			CreateMap<Specialty, SpecialtyDto>()
				.ForMember(x => x.Name, o => o.MapFrom(x => x.SpecialtyBase.Name))
				.ForMember(x => x.SpecialtyBaseId, o => o.MapFrom(x => x.SpecialtyBase.Id))
				.ForMember(x => x.Isceds, o => o.MapFrom(x => x.SpecialtyBase.Isceds));
			CreateMap<Discipline, DisciplineDto>();
			CreateMap<SpecialtyBase, SpecialtyBaseDto>();
			CreateMap<Domain.Region, RegionDto>()
				.ForMember(x => x.Cities, o => o.MapFrom(x => x.Cities));
			CreateMap<City, CityDto>();
			CreateMap<Comment, CommentDto>()
				.ForMember(x => x.Username, o => o.MapFrom(x => x.Author.UserName))
				.ForMember(x => x.Image, o => o.MapFrom(x => x.Author.Photo))
				.ForMember(x => x.DisplayName, o => o.MapFrom(x => x.Author.DisplayName));
			CreateMap<Isced, IscedDto>();
			CreateMap<AppUser, Application.DTOs.Profile>()
				.ForMember(d => d.Photo, o => o.MapFrom(x => x.Photo))
				.ForMember(d => d.University, o => o.MapFrom(s => s.University.Name))
				.ForMember(d => d.SelectedUniversities, o => o.MapFrom(s => s.SelectedUniversities));
			CreateMap<SelectedUniversity, UniversityDto>()
				.ForMember(x => x.Address, o => o.MapFrom(x => x.University.Address))
				.ForMember(x => x.City, o => o.MapFrom(x => x.University.City.Name))
				.ForMember(x => x.Region, o => o.MapFrom(x => x.University.City.Region.Name))
				.ForMember(x => x.Id, o => o.MapFrom(x => x.University.Id))
				.ForMember(x => x.Info, o => o.MapFrom(x => x.University.Info))
				.ForMember(x => x.Name, o => o.MapFrom(x => x.University.Name))
				.ForMember(x => x.Photos, o => o.MapFrom(x => x.University.Photos))
				.ForMember(x => x.TitlePhoto, o => o.MapFrom(x => x.University.TitlePhoto))
				.ForMember(x => x.Telephone, o => o.MapFrom(x => x.University.Telephone))
				.ForMember(x => x.Rating, o => o.MapFrom(x => x.University.Comments.Sum(x => x.Rating) / x.University.Comments.Count))
				.ForMember(x => x.StudentsCount, o => o.MapFrom(x => x.University.StudentsCount))
				.ForMember(x => x.UkraineTop, o => o.MapFrom(x => x.University.UkraineTop))
				.ForMember(x => x.Website, o => o.MapFrom(x => x.University.Website));
			CreateMap<DisciplineDto, Discipline>();
			CreateMap<SpecialtyDto, Specialty>();
			CreateMap<University, University>();
			CreateMap<Specialty, Specialty>();
			CreateMap<Discipline, Discipline>();
			CreateMap<Comment, Comment>();
		}
	}
}