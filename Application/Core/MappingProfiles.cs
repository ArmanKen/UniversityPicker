using Application.DTOs;
using Domain;

namespace Application.Core
{
	public class MappingProfiles : AutoMapper.Profile
	{
		public MappingProfiles()
		{
			CreateMap<AppUser, DTOs.Profile>()
				.ForMember(d => d.Degree, o => o.MapFrom(x => (int?)x.Degree.Id))
				.ForMember(d => d.SpecialtyBase, o => o.MapFrom(x => x.SpecialtyBase.Id))
				.ForMember(d => d.CurrentStatus, o => o.MapFrom(x => (int?)x.CurrentStatus.Id));
			CreateMap<University, UniversityDto>()
				.ForMember(x => x.Region, x => x.MapFrom(x => x.Region.Name))
				.ForMember(x => x.City, x => x.MapFrom(x => x.City.Name))
				.ForMember(x => x.Rating, o => o.MapFrom(x => x.Reviews.Count > 0 ? x.Reviews.Average(x => x.Rating) : 0));
			CreateMap<Faculty, FacultyDto>();
			CreateMap<KnowledgeBranch, KnowledgeBranchDto>();
			CreateMap<SpecialtyBase, SpecialtyBaseDto>();
			CreateMap<Specialty, SpecialtyDto>()
				.ForMember(x => x.Name, o => o.MapFrom(x => x.SpecialtyBase.Name))
				.ForMember(x => x.Degree, o => o.MapFrom(x => x.Degree.Name))
				.ForMember(x => x.SpecialtyBaseId, o => o.MapFrom(x => x.SpecialtyBase.Id))
				.ForMember(x => x.EctsCredits, o => o.MapFrom(x => x.EduComponents.Count > 0 ? x.EduComponents.Sum(x => x.EctsCredits) : 0))
				.ForMember(x => x.Isceds, o => o.MapFrom(x => x.SpecialtyBase.Isceds));
			CreateMap<EduComponent, EduComponentDto>();
			CreateMap<Region, RegionDto>();
			CreateMap<Isced, IscedDto>();
			CreateMap<Review, ReviewDto>()
				.ForMember(x => x.UserName, o => o.MapFrom(x => x.Author.UserName))
				.ForMember(x => x.FullName, o => o.MapFrom(x => x.Author.FullName))
				.ForMember(x => x.Image, o => o.MapFrom(x => x.Author.Photo))
				.ForMember(x => x.FacultyName, o => o.MapFrom(x => x.Faculty.Name));
			CreateMap<FavoriteList, UniversityDto>()
				.ForMember(x => x.Address, o => o.MapFrom(x => x.University.Address))
				.ForMember(x => x.Region, o => o.MapFrom(x => x.University.Region != null ? x.University.Region.Name : null))
				.ForMember(x => x.City, o => o.MapFrom(x => x.University.City != null ? x.University.City.Name : null))
				.ForMember(x => x.Id, o => o.MapFrom(x => x.University.Id))
				.ForMember(x => x.Info, o => o.MapFrom(x => x.University.Info))
				.ForMember(x => x.Name, o => o.MapFrom(x => x.University.Name))
				.ForMember(x => x.TitlePhoto, o => o.MapFrom(x => x.University.TitlePhoto != null ? x.University.TitlePhoto : null))
				.ForMember(x => x.Telephone, o => o.MapFrom(x => x.University.Telephone))
				.ForMember(x => x.Rating, o => o.MapFrom(x => x.University.Reviews.Count > 0 ? x.University.Reviews.Average(x => x.Rating) : 0))
				.ForMember(x => x.StudentsCount, o => o.MapFrom(x => x.University.Faculties.Count > 0 ? x.University.Faculties.Sum(x => x.StudentsCount) : 0))
				.ForMember(x => x.UkraineTop, o => o.MapFrom(x => x.University.UkraineTop))
				.ForMember(x => x.Website, o => o.MapFrom(x => x.University.Website));
			CreateMap<UniversityDto, University>();
			CreateMap<FacultyDto, Faculty>();
		}
	}
}