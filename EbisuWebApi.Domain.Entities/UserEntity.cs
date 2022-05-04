using EbisuWebApi.Crosscutting.Utils;

namespace EbisuWebApi.Domain.Entities
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}