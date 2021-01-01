using AutoMapper;
using Mineral_Management.Business.Models;
using Mineral_Management.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mineral_Management.Data
{

    public class MineralManagementDataProfile : Profile
    {
        public MineralManagementDataProfile()
        {
            CreateMap<ProductBusiness, Product>().ForMember(x => x.InternalId, opt => opt.Ignore());

            CreateMap<Product, ProductBusiness>();

            CreateMap<MineralsBusiness, Minerals>();

            CreateMap<Minerals, MineralsBusiness>();
        }

    }
    
}
