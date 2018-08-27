using System;
using AutoMapper;
using MyBookstore.Core;

namespace MyBookstore.Models
{
    public class ModelMapperConfigs : IMapperConfiguration
    {
        public Action<IMapperConfigurationExpression> GetConfiguration()
        {
            Action<IMapperConfigurationExpression> action = cfg =>
            {
                cfg.CreateMap<AuthorViewModel, Author>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AuthorId));


                cfg.CreateMap<BookViewModel, Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookId));

                cfg.CreateMap<BookViewModel, Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookId));

            };
            return action;


        }


        public int Order
        {
            get { return 1; }
        }
    }
}