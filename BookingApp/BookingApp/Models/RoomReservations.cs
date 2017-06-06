using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;

namespace BookingApp.Models
{
    public class RoomReservations
    {
        //
        public int RoomReservationsId { get; set; }

        private string endDate { get; set; }
        private string startDate { get; set; }
        private Timer timestamp { get; set; }
        public List<User> l_User { get; set; }
        public List<Room> l_Room { get; set; }
        // 1
        public int RoomId { get; set; }

        public Room Room { get; set; }
        // 2
        public int UserId { get; set; }

        public User  User { get; set; }

        public RoomReservations()
        {

        }

        ~RoomReservations()
        {

        }


    

    }//end RoomReservations
}