using AutoMapper;
using Shop.Application.Carts.Queries.GetCart;
using Shop.Application.Customers.Queries.GetCustomerDetails;
using Shop.Application.Customers.Queries.GetCustomerOrders;
using Shop.Application.Orders.CreateOrder;
using Shop.Application.Products.Queries.GetProduct;
using Shop.Domain.Models;


namespace Shop.Application.Utils
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<Customer, CustomerDetailsDto>();

            CreateMap<Address, AddressDto>();

            CreateMap<ProductItem, OrderItemDto>()
                .ForMember(o => o.Id, p => p.MapFrom(p => p.Product.Id))
                .ForMember(o => o.Name, p => p.MapFrom(p => p.Product.Name))
                .ForMember(o => o.Code, p => p.MapFrom(p => p.Product.Code))
                .ForMember(o => o.Slug, p => p.MapFrom(p => p.Product.Slug))
                .ForMember(o => o.Price, p => p.MapFrom(p => p.Product.Price))
                .ForMember(o => o.Total, p => p.MapFrom(src => src.Product.Price * src.Quantity));

            CreateMap<Order, OrderDto>();
            CreateMap<Cart, CartDto>();
        }
    }
}
