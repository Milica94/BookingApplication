using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Accommodation
    {

        public int AccommodationId { get; set; }
        public string address { get; set; }
        public bool approved { get; set; }
        public float averageGrade { get; set; }
        public string description { get; set; }

        public string imageURL { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string name { get; set; }
        public List<Comment> l_Comment { get; set; }
        public List<Room> l_Room { get; set; }
        // 1
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        // 2
        public int AccommodationTypeId { get; set; }
        public AccommodationType AccommodationType { get; set; }

        public Accommodation()
        {

        }

        ~Accommodation()
        {

        }
        

    }//end Accommodation
}
