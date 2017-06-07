using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Room
    {

        public int RoomId { get; set; }
        public int bedCount { get; set; }
        public string description { get; set; }

        public int pricePerNight { get; set; }
        public int roomNumber { get; set; }
        public List<RoomReservations> l_RoomReservations { get; set; }
        //
        public int AccommodationId { get; set; }

        public Accommodation Accommodation { get; set; }

        public Room()
        {

        }

        ~Room()
        {

        }

       

    }//end Room
}
