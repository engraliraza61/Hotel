using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DBClass
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserTitle { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string RoomBooked { get; set; }
        public DateTime RoomBookedArrivalDate { get; set; }
        public DateTime RoomBookedDepartDate { get; set; }
        public string Massage { get; set; }
        public int UserStatus { get; set; }
        public string RoleTitle { get; set; }
        public DateTime InsertionDateTime { get; set; }
    }
}
