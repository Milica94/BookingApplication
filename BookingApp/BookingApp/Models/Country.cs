using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Country
    {

        public int CountryId { get; set; }
        private int code { get; set; }

        private string name;
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