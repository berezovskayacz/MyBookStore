using System;
using System.Linq;
using AutoMapper;
using MyBookstore.Core;
using System.Collections.Generic;

namespace MyBookstore.Models
{
    public class EntityMapperConfigs : IMapperConfiguration
    {
        public Action<IMapperConfigurationExpression> GetConfiguration()
        {
            Action<IMapperConfigurationExpression> action = cfg =>
            {

                cfg.CreateMap<Author, AuthorViewModel>()
                    .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                    .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Id));

                cfg.CreateMap<Book, BookViewModel>()
                    .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.ThumbnailName, opt => opt.MapFrom(src => src.Pictures.Where(t => t.Main).Select(t => string.Concat(t.Id.ToString(), "_", t.Name)).FirstOrDefault()))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

                cfg.CreateMap<List<ShoppingCartItem>, ShoppingCartModel>()
                     .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.FirstOrDefault().User))
                     .ForMember(dest => dest.ShoppingCartItems, opt => opt.MapFrom(src => src));

                cfg.CreateMap<ShoppingCartItem, ShoppingCartItemModel>();

                cfg.CreateMap<ApplicationUser, UserViewModel>()
                     .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Email))
                     .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            };
            return action;
        }

        public int Order
        {
            get { return 0; }
        }
    }
}