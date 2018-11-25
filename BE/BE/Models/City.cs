using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Models
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public City()
        {
        }

        public City(int _CityID, string _CityName, string _Country, string _Latitude, string _Longitude)
        {
            CityID = _CityID;
            CityName = _CityName;
            Country = _Country;
            Longitude = _Longitude;
            Latitude = _Latitude;
        }
                
    }


}
