namespace API.Dto
{
    public class DirectMessageDto
    {
        public int Sender { get; set; }

        public int Receiver { get; set; }
        
        public string? Message { get; set; }

        public DateTime TimeSent {get; set;}
    }
}