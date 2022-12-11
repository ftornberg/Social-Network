namespace API.Dto.User;

public class UserGetDto : BaseEntity
{
    public string? Name { get; set; }

    public string? Email { get; set; }
    
    public DateTime CreatedTime { get; set; }
}
