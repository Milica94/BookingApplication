using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Accommodation
    {

        public int AccommodationId { get; set; }
        private string address { get; set; }
        private bool approved { get; set; }
        private float averageGrade { get; set; }
        private string description { get; set; }

        private string imageURL { get; set; }
        private double latitude { get; set; }
        private double longitude { get; set; }
        private string name { get; set; }
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