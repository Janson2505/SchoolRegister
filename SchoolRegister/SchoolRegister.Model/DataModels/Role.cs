using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Role : IdentityRole<int>
    {
        public virtual RoleValue RoleValue { get; set; }

        public Role() { }

        public Role(string name, RoleValue roleValue)
        {
            Name = name;
            RoleValue = roleValue;
        }
    }
}
