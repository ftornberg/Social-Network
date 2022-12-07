namespace API.Dto;

public class UserUpdateDto : UserCredentialsDto
{
  public string OldProperty { get; set; }
  
  public string UpdatedProperty { get; set; }
}