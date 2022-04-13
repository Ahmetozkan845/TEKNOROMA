using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Controllers
{

    //MVC --Controller işin mutfak kısmı
    // Data kısmı verilerin tutulması çağırılması vs
    //View kısmı görüntüleme her controller in bir view karşılığı var
    //Oluşturulan controllerlar çoğul olmamalı oluşturulacak farklı parametrelerde çoğul eki alacağı için karışıklık olmamalı
    //Seperation of concenrs 
    //Sorumlulukların ayrılması
    //ActionResult Controller yapısına gelen isteklere göre işlem yapıp kullanıcıya View ile isteğe göre bilgileri geri döndüren metotlara verilen isim.
    //List Create Update Delete İşlem Metodları
    //Razor View Engine => Html içerisinde C# kodları olarak yazılmasını sağlar "@" etiketinden sonra yazdığında algılama sağlanır
    //Html de sayfayı viewde yakalamak için Viewbag.Value yapısı kullanılıyor nasıl ve neden ARAŞTIR.
    //LoginController [HttpPost] denendi çalıştı 
    //[HttpGet]=>Verileri Teslim al Encapsulation gibi
    //[HttpSet]=>Verileri teslim et 
    //Layout = Sabit olan html etiketleri tanımlanması Örn: Navbar
    //View içinde Share klasörü oluşturup tüm sayfalar tarafından ortak kullanılacak etiketleri burda tanımlayabilirsin
    //Layout içerisinde dinamik bir yapı oluşturmak ( render etmek) için Razor yapıısı kullanılır
    //@Renderbody{} çözümlenmesi çin gerekli olan yapı
    //COntent dışardan proje içinde kullanacağımız dosyaları temsil ediyor örneğin css javascript 
    //Partial => dışarda bir sayfa oluşturup istediğinde gösterme
    //Helpers => @html. C# olarak  tanımlanan ama html'e rrender edilen metodlara dönşür
    //ViewData & ViewBag mvc 3 ile gelen viewdata dan farkı viewbag key değeri yerine doğrudan dinamik olarak tanımlanır.
    //TempData ( geçici data) ViewBag ile aynı mantığa sahip farkı ise action içerisinde tanımlandıktan sonra bir başka sayfadan çağırılmasıdır.
    //Null geçilebilir => örneğin public ActionResult Details(string ProductName, int?) soru işareti eklediğinde null geçilebilir oluyor.
    //Area kısmı web kısmını birden fazla alana ayırmak için kullanman gerekir yani admin manager user gibi ayırma 

    public class HomeController : Controller
    {
        // İstek İlk Buraya Düşecek.
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}