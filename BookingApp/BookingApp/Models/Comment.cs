using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Comment
    {

        public int CommentId { get; set; }
        public int grade { get; set; }
        public string text { get; set; }
        public List<User> l_User { get; set; }
        public List<Accommodation> l_Accommodation;
        //
        public int UserId { get; set; }

        public User User { get; set; }

        public Comment()
        {

        }

        ~Comment()
        {

        }

    
        

      

    }//end Comment
}
