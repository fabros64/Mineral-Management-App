using AutoMapper;
using Mineral_Management.API.Models;
using Mineral_Management.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mineral_Management.Data.Models;

namespace Mineral_Management.API
{
    public class Mineral_ManagementProfile : Profile
    {     
            public Mineral_ManagementProfile()
            {
                CreateMap<ProductBusiness, ProductParam>();
                CreateMap<ProductParam, ProductBusiness>();
                CreateMap<ProductBusiness, Product>();
                CreateMap<Product, ProductBusiness>();
                CreateMap<MineralsBusiness, MineralsParam>();
                CreateMap<MineralsParam, MineralsBusiness>();
                CreateMap<MineralsBusiness, Minerals>();
                CreateMap<Minerals, MineralsBusiness>();
            }
        
    }
}
