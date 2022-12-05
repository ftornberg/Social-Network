using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class DirectMessageDto
    {
        public int Sender { get; set; }

        public int Reciever { get; set; }
        
        public string? Message { get; set; }

        public DateTime TimeSent {get; set;}
    }
}