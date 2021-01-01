namespace Mineral_Management.Data.Models
{
  
        public class Mineral_Management_ApiDbSettings : IMineral_Management_ApiDbSettings
        {
            public Mineral_Management_ApiDbSettings()
            {
            }
            public string GeoCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }

        public interface IMineral_Management_ApiDbSettings
        {
            string GeoCollectionName { get; set; }
            string ConnectionString { get; set; }
            string DatabaseName { get; set; }
        }  
}