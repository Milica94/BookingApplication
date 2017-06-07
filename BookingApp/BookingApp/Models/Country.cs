using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Country
    {

        public int CountryId { get; set; }
        public int code { get; set; }

        public string name;
        public List<Region> l_Region { get; set; }
        //

        public Country()
        {

        }

        ~Country()
        {

        }

       

    }//end Country
}
