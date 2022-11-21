namespace Entity;
public class User
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string ?ProfilePersonalPicture { get; set; }

    public string ?ProfileBackgroundPicture { get; set; }

    public int Age { get; set; }

    public string ?Biography { get; set; }

    public Introduction ?Introduction { get; set; }
    
    public List<string> ?Hobbies { get; set; }
}
