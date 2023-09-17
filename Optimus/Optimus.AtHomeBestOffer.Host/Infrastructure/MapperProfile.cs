using AutoMapper;
using Optimus.AtHomeBestOffer.Application.Dto;
using Optimus.AtHomeBestOffer.Application.Model;

namespace Optimus.AtHomeBestOffer.Host.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Order, Company1OrderDto>()
                .ForMember(dest => dest.ContactAddress, opt => opt.MapFrom(src => src.SourceAddress))
                .ForMember(dest => dest.WarehouseAddress, opt => opt.MapFrom(src => src.DestinationAddress))
                .ForMember(dest => dest.PackageDimensions, opt => opt.MapFrom(src => src.CartonDimensions));

            CreateMap<Order, Company2OrderDto>()
                .ForMember(dest => dest.Consignee, opt => opt.MapFrom(src => src.SourceAddress))
                .ForMember(dest => dest.Consignor, opt => opt.MapFrom(src => src.DestinationAddress))
                .ForMember(dest => dest.Cartons, opt => opt.MapFrom(src => src.CartonDimensions));

            CreateMap<Package, Dimensions>().ReverseMap();

            CreateMap<Order, Company3OrderDto>()
                 .ForMember(dest => dest.Source, opt => opt.MapFrom(src => src.SourceAddress))
                .ForMember(dest => dest.Destination, opt => opt.MapFrom(src => src.DestinationAddress))
                .ForMember(dest => dest.Packages, opt => opt.MapFrom(src => src.CartonDimensions));

            CreateMap<Company1ProposedOffer, ProposedOffer>()
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total));

            CreateMap<Company2ProposedOffer, ProposedOffer>()
             .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Amount));

            CreateMap<Company3ProposedOffer, ProposedOffer>()
                  .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Quote));
        }
    }
}