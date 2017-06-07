using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Region
    {

        public int RegionId { get; set; }
        public string name { get; set; }
        public List<Place> l_Place { get; set; }
        // 
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public Region()
        {

        }

        ~Region()
        {

        }

    
       

    }//end Region

}
