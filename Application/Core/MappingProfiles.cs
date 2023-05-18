using Application.DTOs;
using Domain;

namespace Application.Core
{
	public class MappingProfiles : AutoMapper.Profile
	{
		public MappingProfiles()
		{
			var username = "";
			CreateMap<AppUser, DTOs.Profile>()
				.ForMember(d => d.SpecialtyBase, o => o.MapFrom(x => x.SpecialtyBase));
			CreateMap<HigherEducationFacility, HigherEducationFacilityDto>()
				.ForMember(x => x.InFavoriteList, o => o.MapFrom(x => x.FavoriteList.FirstOrDefault(x => x.AppUser.UserName == username) != default))
				.ForMember(x => x.StudentsCount, o => o.MapFrom(x => x.Faculties.Sum(x => x.StudentsCount)))
				.ForMember(x => x.Rating, o => o.MapFrom(x => x.Reviews.Count > 0 ? x.Reviews.Average(x => x.Rating) : 0));
			CreateMap<Region, RegionDto>();
			CreateMap<Faculty, FacultyDto>()
				.ForMember(x => x.HigherEducationFacilityId, o => o.MapFrom(x => x.HigherEducationFacility.Id));
			CreateMap<Language, LanguageDto>();
			CreateMap<StudyForm, StudyFormDto>();
			CreateMap<KnowledgeBranch, KnowledgeBranchDto>();
			CreateMap<SpecialtyBase, SpecialtyBaseDto>();
			CreateMap<SpecialtyBase, SpecialtyBaseIscedDto>();
			CreateMap<Specialty, SpecialtyDto>()
				.ForMember(x => x.FacultyId, o => o.MapFrom(x => x.Faculty.Id))
				.ForMember(x => x.HigherEducationFacilityId, o => o.MapFrom(x => x.Faculty.HigherEducationFacility.Id))
				.ForMember(x => x.EctsCredits, o => o.MapFrom(x => x.EduComponents.Count > 0 ? x.EduComponents.Sum(x => x.EctsCredits) : 0));
			CreateMap<EduComponent, EduComponentDto>();
			CreateMap<Isced, IscedDto>();
			CreateMap<Review, ReviewDto>()
				.ForMember(x => x.UserName, o => o.MapFrom(x => x.Author.UserName))
				.ForMember(x => x.FullName, o => o.MapFrom(x => x.Author.FullName))
				.ForMember(x => x.Image, o => o.MapFrom(x => x.Author.Photo));
			CreateMap<FavoriteList, HigherEducationFacilityDto>()
				.ForMember(x => x.Address, o => o.MapFrom(x => x.HigherEducationFacility.Address))
				.ForMember(x => x.Region, o => o.MapFrom(x => x.HigherEducationFacility.Region != null ? x.HigherEducationFacility.Region.Name : null))
				.ForMember(x => x.City, o => o.MapFrom(x => x.HigherEducationFacility.City != null ? x.HigherEducationFacility.City.Name : null))
				.ForMember(x => x.Id, o => o.MapFrom(x => x.HigherEducationFacility.Id))
				.ForMember(x => x.Info, o => o.MapFrom(x => x.HigherEducationFacility.Info))
				.ForMember(x => x.Name, o => o.MapFrom(x => x.HigherEducationFacility.Name))
				.ForMember(x => x.TitlePhoto, o => o.MapFrom(x => x.HigherEducationFacility.TitlePhoto))
				.ForMember(x => x.Telephone, o => o.MapFrom(x => x.HigherEducationFacility.Telephone))
				.ForMember(x => x.Rating, o => o.MapFrom(x => x.HigherEducationFacility.Reviews.Count > 0 ? x.HigherEducationFacility.Reviews.Average(x => x.Rating) : 0))
				.ForMember(x => x.StudentsCount, o => o.MapFrom(x => x.HigherEducationFacility.Faculties.Count > 0 ? x.HigherEducationFacility.Faculties.Sum(x => x.StudentsCount) : 0))
				.ForMember(x => x.UkraineTop, o => o.MapFrom(x => x.HigherEducationFacility.UkraineTop))
				.ForMember(x => x.Location, o => o.MapFrom(x => x.HigherEducationFacility.Location))
				.ForMember(x => x.Accreditation, o => o.MapFrom(x => x.HigherEducationFacility.Accreditation))
				.ForMember(x => x.InFavoriteList, o => o.MapFrom(x => x.AppUser.UserName == username))
				.ForMember(x => x.Website, o => o.MapFrom(x => x.HigherEducationFacility.Website));
			CreateMap<HigherEducationFacilityDto, HigherEducationFacility>();
			CreateMap<KnowledgeBranchDto, KnowledgeBranch>();
			CreateMap<LanguageDto, Language>();
			CreateMap<RegionDto, Region>();
			CreateMap<FacultyDto, Faculty>();
			CreateMap<SpecialtyDto, Specialty>();
			CreateMap<SpecialtyBaseDto, SpecialtyBase>();
			CreateMap<SpecialtyBaseIscedDto, SpecialtyBase>();
			CreateMap<StudyFormDto, StudyForm>();
			CreateMap<IscedDto, Isced>();
			CreateMap<EduComponentDto, EduComponent>();
			CreateMap<ReviewDto, Review>();
		}
	}
}