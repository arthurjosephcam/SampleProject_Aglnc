using AutoMapper;
using MarketInventory.Service;
using MarketInventory.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketInventory.WebApplication
{
    internal sealed class Mapper
    {

        private static readonly Lazy<IMapper> LazyMapper = new Lazy<IMapper>(() => {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Service.Models.ProductInventory, ProductInventory>().ReverseMap();
            });
            return config.CreateMapper();
        });

        public static T Map<T>(Object Source)
        {

            return LazyMapper.Value.Map<T>(Source);
        }

        public static TDestination Map<TSource, TDestination>(TSource Source)
        {
            return LazyMapper.Value.Map<TSource, TDestination>(Source);
        }
    }
}
