using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.SingletonPattern
{
    public class DBTool
    {
        //Veri tabanından örnek almak için singleton patternt kullanıldı
        //private ve public olarak oluştur(private için şuan bir kısıt yok eğer olursa private tanımla)
        //static MyContext(database kaatmanından) _dbInstance olarak tanımla 
        //EntityFramework kuruldu.

        DBTool() { }

        static MyContext _dbInstance;

        public static MyContext DBInstance
        {
            get
            {
                if (_dbInstance == null)
                {
                    _dbInstance = new MyContext();
                }
                return _dbInstance;
            }



        }



    }
}
