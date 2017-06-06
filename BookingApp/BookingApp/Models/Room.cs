using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Room
    {

        public int RoomId { get; set; }
        private int bedCount { get; set; }
        private string description { get; set; }

        private int pricePerNight { get; set; }
        private int roomNumber { get; set; }
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