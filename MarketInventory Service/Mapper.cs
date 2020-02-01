using AutoMapper;
using MarketInventory.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketInventory.Service
{
    internal sealed class Mapper
    {

        private static readonly Lazy<IMapper> LazyMapper = new Lazy<IMapper>(() => {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<Repository.Models.ProductInventory, Models.ProductInventory>().ReverseMap();
                //cfg.CreateMap<Repository.Models.SalesData, Models.SalesData>()
                // .ForMember(dest => dest.CustomerData, target => target.MapFrom(s => s.CustomerData))
                //  .ForMember(dest => dest.TileData, target => target.MapFrom(s => s.TileData))
                //  .ReverseMap(); 
                
                //I left it here to provide an example to complicated mapping. While I was copying it from my
                //Other Project, I did not want to delete this part.

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
