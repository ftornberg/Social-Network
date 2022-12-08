namespace Entity;

public class User : BaseEntity
{
    public User()
    {
    }

    public User(string name, string email, string password, DateTime createdTime)
    {
        Name = name;
        Email = email;
        Password = password;
        CreatedTime = createdTime;
    }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public DateTime CreatedTime { get; set; }
}