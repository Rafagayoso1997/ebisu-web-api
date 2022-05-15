namespace EbisuWebApi.Application.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is UserDto dto &&
                   UserId == dto.UserId &&
                   UserName == dto.UserName &&
                   Password == dto.Password &&
                   Email == dto.Email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserId, UserName, Password, Email);
        }
    }
}
