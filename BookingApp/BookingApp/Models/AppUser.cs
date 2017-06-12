using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(25), Index(IsUnique =true)]
        public string FullName { get; set; }

        public IList<RoomReservations> RReservations { get; set; }

        public IList<Room> Property_Rooms { get; set; }

        public IList<Accommodation> Acoomodations { get; set; }
    }
}