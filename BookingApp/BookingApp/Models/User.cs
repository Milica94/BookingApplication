using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class User
    {

        public int UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string Username { get; set; }
        public List<Comment> l_Comment { get; set; }
        public List<RoomReservations> l_RoomReservations { get; set; }
        public List<Accommodation> l_Accommodation { get; set; }
        //


        public User()
        {

        }

        ~User()
        {

        }
        
    }//end User

}