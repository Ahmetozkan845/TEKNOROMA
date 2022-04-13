using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public abstract class BaseMap<T>:EntityTypeConfiguration<T> where T:BaseEntity
    {
        
        // wheere komutu ile sadece sadece Entity içerisindeki BaseEntityden miras alacak.
        //işlem bittikten sonra sql server üzerinde kısıtlama yapmak istersen burada gerçekleştir.
        public BaseMap()
        {

        }
    }
}
