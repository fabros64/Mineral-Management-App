using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mineral_Management.API.Models
{
    public class ProductParam
    {
        public  string ProductId{ get; set; }

        public  string Name { get; set; }

        public string Description { get; set; }

        public string ImageSource  { get; set; } // https://www.codementor.io/@mhusain/store-images-in-mongodb-using-dotnet-core-3-0-101j7o2dgt

        public string ImageName { get; set; }

        public MineralsParam Minerals  { get; set; }

        public string products { get; set; }

        public string UserId { get; set; }
    }
}
