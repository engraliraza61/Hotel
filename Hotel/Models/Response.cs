using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Response
    {

        public string Status { get; set; } 
        public int Id { get; set; } 
        public string Token { get; set; }

    }
    public class ListClass : Response
    {
        public dynamic Data { get; set; }
        public int TotalPages { get { return ((TotalRecords + PageSize - 1)) / PageSize; } }
        public int TotalRecords { get; set; }
        public int PageSize { get { return 7; } }
        public int CurrentPage { get; set; }
    }
}
