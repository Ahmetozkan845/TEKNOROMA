using Project.BLL.DesignPatterns.GenericRepository.IntRep;
using Project.BLL.DesignPatterns.SingletonPattern;
using Project.DAL.Context;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.BaseRep
{
    //Base-->Onculuk eden repository tanımla 
    // T entity tipi şu an veritabanındaki tablolarımıza karşılık gelmektedir 
    //Implemente ettiğinde işlemleri getirecek önce IRepository işlemlerini tanımla
    //Bu katmanı ilerde oluşturacağım katmana taşıyabilirim test et sonucaa göre şekillenecektir.

    public abstract class BaseRepository<T>:IRepository<T> where T:BaseEntity
    {

        //veri tabanı örneği alarak başla
        MyContext _db;

        public BaseRepository()
        {
            _db = DBTool.DBInstance;
        }

        void Save()
        {
            //Veri kaynağındaki tüm güncelleştirmeleri devam ettirir ve nesne bağlamındaki değişiklik izlemeyi sıfırlar
            //Bu yapıyı kullanma sebebimiz EntitFramework e bağımlı kalmamak için
            _db.SaveChanges();
        }

        public void Add(T item)
        {
            //veri ekleme ve tutma 
            //Save ()
            _db.Set<T>().Add(item);
            Save();
        }

        public void AddRange(List<T> item)
        {
            //Her list kullanımında döngü kullanmama gerek yok hazır metod çalışabilir
            //AddRange => Belirtilen koleksiyonun öğelerini sonuna List<T> ekler.
            //AddRange => Elimizfr liste varsa liste elemanlarını veri tabanında <T> set etmiş olduğu tabloya tek tek dahil et anlamına geliyor 
            //Sonrasında Save et 
            _db.Set<T>().AddRange(item);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            //Expression ifade metodu

            return _db.Set<T>().Any(exp);
        }

        public void Delete(T item)
        {
            //Silme işlemi 
            //Veri gelmesi için Enum içerisinde tanımlı içerisinde tanımşı upload delete gibi işlemler verdim
            //Status durum değiştirme komutu
            item.Status = ENTITIES.Enums.DataStatus.Deleted;

            item.DeletedDate = DateTime.Now;

            Save();
        }

        public void DeleteRange(List<T> item)
        {
            //List tipinde gönderdildiği için döngü kullanmayı denedim.
            foreach (T eleman in item)
            {
                Delete(eleman);
            }
        }

        public void Destroy(T item)
            //Destroy=veriyi yoketmek için kullanılan komut
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public void DestroyRange(List<T> item)
        {
            foreach (T eleman in item)
            {
                Destroy(eleman);
            }
        }

        public T Find(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            //expression=> ifade 

            //Bir koşulu karşılayan dizinin ilk öğesini veya böyle bir öğe bulunmazsa belirtilen varsayılan değeri döndürür.
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            //Aktif et
            return Where(x => x.Status != ENTITIES.Enums.DataStatus.Deleted);
        }

        public List<T> GetAll()
        {//Belirtilen elementlerin hepsini al
            return _db.Set<T>().ToList();
        }

        public List<T> GetModifieds()
        {
            //Düzenleme 
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Updated);
        }

        public List<T> GetPassives()
        {
            //Aktif olmaktan çıkar
            //Enum içerisinde tanımlanan komut
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp).ToList();
        }

        public void Update(T item)
        {
            //Güncelleme işlemleri 
            //Çalışmıyor düzenle 
            //tobeupdated araştır kullan?
            item.Status = ENTITIES.Enums.DataStatus.Updated;
            //Delete de olduğu gibi enum içerisinde çalıştırıldı.
            item.ModifiedDate = DateTime.Now;


            //entry de kullanılabilir  
            T toBeUpdated = Find(item.ID);
            //entry => girdi oluşturma 
            //veri tabanındaki girdilerden tobeuploaded e git anlamında 
            _db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            Save();
            //CurrentValues parametreden almış olduğun modele göre set etme 
        }

        public void UpdateRange(List<T> item)
        {
            foreach (T eleman in item)
            {
                Update(eleman);
            }
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }
        //yoruldum
        public T FindFirstData()
        {
            return GetAll().FirstOrDefault();
        }

        public T FindLastData()
        {
            return _db.Set<T>().OrderByDescending(x => x.CreatedDate).FirstOrDefault();
        }

        
    }
}
