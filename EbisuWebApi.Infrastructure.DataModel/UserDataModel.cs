﻿
namespace EbisuWebApi.Infrastructure.DataModel
{
    public class UserDataModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<CategoryDataModel> Categories { get; set; }

        public ICollection<RoleDataModel> Roles { get; set; }
    }
}