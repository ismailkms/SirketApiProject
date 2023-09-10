using AutoMapper;
using DTOLayer.DTOs.DepartmanDTOs;
using DTOLayer.DTOs.PersonelDTOs;
using DTOLayer.DTOs.RoleDTOs;
using DTOLayer.DTOs.SirketDTOs;
using EntityLayer.Concrete;

namespace SirketAPI.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<SirketAddDTO, Sirket>();
            CreateMap<Sirket, SirketAddDTO>();
            CreateMap<SirketUpdateDTO, Sirket>();
            CreateMap<Sirket, SirketUpdateDTO>();

            CreateMap<DepartmanAddDTO, Departman>();
            CreateMap<Departman, DepartmanAddDTO>();
            CreateMap<DepartmanUpdateDTO, Departman>();
            CreateMap<Departman, DepartmanUpdateDTO>();

            CreateMap<PersonelAddDTO, Personel>();
            CreateMap<Personel, PersonelAddDTO>();
            CreateMap<PersonelUpdateDTO, Personel>();
            CreateMap<Personel, PersonelUpdateDTO>();

            CreateMap<RoleAddDTO, Role>();
            CreateMap<Role, RoleAddDTO>();
            CreateMap<RoleUpdateDTO, Role>();
            CreateMap<Role, RoleUpdateDTO>();
        }

    }
}
