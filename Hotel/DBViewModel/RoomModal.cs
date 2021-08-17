using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DBViewModel
{
    public class RoomModal
    {
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public string AC { get; set; }
        public string Food { get; set; }
        public int BedCount { get; set; }
        public string ChargeForCancellation { get; set; }
        public int Rent { get; set; }
        public String PhoneNo { get; set; }
        public String Photo { get; set; }
        public String Massage { get; set; }
    }
}
