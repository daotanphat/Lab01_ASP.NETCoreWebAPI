using AutoMapper;
using BusinessObjects;
using BusinessObjects.Dtos;

namespace ProjectManagementAPI.Mapper
{
	public class ProductMapper : Profile
	{
		public ProductMapper()
		{
			CreateMap<CreateProductDto, Product>().ReverseMap();
			CreateMap<UpdateProductDto, Product>().ReverseMap();
			CreateMap<Product, ProductResponseDto>().ForMember(
				dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName)).ReverseMap();
		}
	}
}
