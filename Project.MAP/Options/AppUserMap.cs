using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class AppUserMap:BaseMap<AppUser>
    {
        public AppUserMap()
        {
            //HasOptional(x Entity içerisinde tanımlı virtual tanımlı AppUsere gitsin)
            //(WithRequired Entity içerisindeki AppUsere gitsin
            // eğer ignore => görmezden gelme anlamında eğer bunu atlayabilirse password doğrulamasına gönder.

            HasOptional(x => x.Profile).WithRequired(x => x.AppUser);


            Ignore(x => x.ConfirmPassword);
        }
    }
}
