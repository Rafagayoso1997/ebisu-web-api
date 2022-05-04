﻿using EbisuWebApi.Crosscutting.Utils;

namespace EbisuWebApi.Infrastructure.DataModel
{
    public class UserDataModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public ICollection<CategoryDataModel> Categories { get; set; }
    }
}