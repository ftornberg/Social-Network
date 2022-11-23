using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class DirectMessageDto
    {
        public DateTime TimeSent {get; set;}

        public Guid Sender { get; set; }

        public Guid Reciever { get; set; }

        public string? Message { get; set; }
    }
}