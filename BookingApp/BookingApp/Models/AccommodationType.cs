using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class AccommodationType
    {

        public int AccommodationTypeId { get; set; }
        private string name { get; set; }
        public List<Accommodation> l_Accommodation { get; set; }
        //

        public AccommodationType()
        {

        }

        ~AccommodationType()
        {

        }

       

       
    }//end AccommodationType
}