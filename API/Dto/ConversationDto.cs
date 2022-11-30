using Entity;

namespace API.Dto 
{
    public class ConversationDto
    {
        public ICollection<DirectMessage>? Messages { get; set; }
    }
}