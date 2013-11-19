using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomizedMemebershipModel.Models
{
    public class User : IdentityUser
    {
        public string Nickname { get; set; }
    }
}