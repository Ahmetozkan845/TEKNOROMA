using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WEBUI.VMClasses
{
    public class AppUserVM
     //Aracı katman gerekli olan properttyleri kullanmak için tanımlandı 
    {
        public AppUser AppUser { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public List<Order> Orders { get; set; }
        public UserProfile Profile { get; set; }
        public List<UserProfile> UserProfiles { get; set; }

    }
}