namespace HaadEdu.Application.Dtos.UserDTOs;

public class UserForchangePassword
{
    public string Username { get; set; }
    public string OldPassword {  get; set; }
    public string NewPassword { get; set; }
}
