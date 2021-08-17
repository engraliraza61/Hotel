using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DBClass
{
    public class Rooms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public string AC { get; set; }
        public string Food { get; set; }
        public int BedCount { get; set; }
        public string ChargeForCancellation { get; set; }
        public int Rent { get; set; }
        public string PhoneNo { get; set; }
        public string Photo { get; set; }
        public string Massage { get; set; }
        public DateTime InsertDateTime { get; set; }
        public short Status { get; set; }
    }
}
