using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Place
    {

        public int PlaceId { get; set; }
        public string name { get; set; }
        public List<Accommodation> l_Accommodation { get; set; }
        //
        public int RegionId { get; set; }
        public Region Region { get; set; }

        public Place()
        {

        }

        ~Place()
        {

        }

        

       

    }//end Place
}
