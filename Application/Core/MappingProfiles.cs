using Application.DTOs;
using AutoMapper;
using Domain;

namespace Application.Core
{
	public class MappingProfiles : AutoMapper.Profile
	{
		public MappingProfiles()
		{
			CreateMap<University, UniversityDto>()
				.ForMember(x => x.Region, o => o.MapFrom(x => x.City != null ? x.City.Region.Name : null))
				.ForMember(x => x.City, o => o.MapFrom(x => x.City != null ? x.City.Name : null))
				.ForMember(x => x.Rating, o => o.MapFrom(x => x.Comments.Count() > 0 ? x.Comments.Average(x => x.Rating) : 0));
			CreateMap<Specialty, SpecialtyDto>()
				.ForMember(x => x.Name, o => o.MapFrom(x => x.SpecialtyBase.Name))
				.ForMember(x => x.Degree, o => o.MapFrom(x => x.Degree.Name))
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
				.ForMember(d => d.Photo, o => o.MapFrom(x => x.Photo != null ? x.Photo : null))
				.ForMember(d => d.Degree, o => o.MapFrom(x => x.Degree.Name))
				.ForMember(d => d.University, o => o.MapFrom(s => s.University));
			CreateMap<SelectedUniversity, UniversityDto>()
				.ForMember(x => x.Address, o => o.MapFrom(x => x.University.Address))
				.ForMember(x => x.City, o => o.MapFrom(x => x.University.City != null ? x.University.City.Name : null))
				.ForMember(x => x.Region, o => o.MapFrom(x => x.University.City != null ? x.University.City.Region.Name : null))
				.ForMember(x => x.Id, o => o.MapFrom(x => x.University.Id))
				.ForMember(x => x.Info, o => o.MapFrom(x => x.University.Info))
				.ForMember(x => x.Name, o => o.MapFrom(x => x.University.Name))
				.ForMember(x => x.TitlePhoto, o => o.MapFrom(x => x.University.TitlePhoto != null ? x.University.TitlePhoto : null))
				.ForMember(x => x.Telephone, o => o.MapFrom(x => x.University.Telephone))
				.ForMember(x => x.Rating, o => o.MapFrom(x => x.University.Comments.Count() > 0 ? x.University.Comments.Average(x => x.Rating) : 0))
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