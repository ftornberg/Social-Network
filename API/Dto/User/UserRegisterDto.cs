namespace API.Dto;

public class UserRegisterDto : UserCredentialsDto
{
    public string? Name { get; set; }

    public DateTime CreatedTime { get; set; } = DateTime.Now;
}