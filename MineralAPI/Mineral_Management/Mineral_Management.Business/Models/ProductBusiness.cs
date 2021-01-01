using System;
using System.Collections.Generic;
using System.Text;

namespace Mineral_Management.Business.Models
{
    public class ProductBusiness
    {
        public string ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageSource { get; set; }

        public string ImageName { get; set; }

        public MineralsBusiness Minerals { get; set; }

        public string products { get; set; }

        public string UserId { get; set; }
    }
}
