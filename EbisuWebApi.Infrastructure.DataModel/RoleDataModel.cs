using EbisuWebApi.Crosscutting.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Infrastructure.DataModel
{
    public class RoleDataModel
    {
        public int RoleId { get; set; }

        public Role RoleType { get; set; }

        public ICollection<UserDataModel> Users { get; set; }
    }
}
