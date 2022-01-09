 ## KULLANILAN PAKETLER
- MongoDB.Driver  -->  ".Net" için resmi MongoDb driverıdır.
- System.IdentityModel.Tokens.Jwt  -->  JSON Web Tokenleri oluşturmak ve doğrulamak için destek sağlayan türleri içerir.
- microsoft.VisualStudio.Azure.Containers.Tools.Targets  -->  Konteynerler için Visual Studio aracıdır.
- Swashbuckle.AspNetCore  -->  ASP.Net Core ile geliştirilen API'leri dökümante etmek için kullanılan swagger aracıdır.
- AspNetCore.HealthChecks.MongoDb  -->  MongoDb'nin sorun denetimi paketidir.

 ## PROJE MİMARİSİ
- Controllers  -->  Web API Controlleri, Asp.Net MVC Controllere benzerdir. Gelen HTTP istekleriyle ilgilenir ve gelen isteklere geri cevap gönderir.
- DTOS  -->  Entitylerin, frontendte kullanmak üzere oluşturduğumuz versiyonlarını içerir.
- Entities  --> Veri tabanındaki neslerin veri yapılarını içerir.
- Helpers  -->  Projedeki farklı yerlerde kullanılacak olan ortak fonksiyonlar burada bulunur.
- Interfaces  -->  Interfaceleri içeren klasördür.
- Repositories  -->  Controller ile MongoDb arasındaki katmanları içerir.
- Services  -->  Bazı servisleri içeren klasördür.
- Settings  -->  MongoDbSettings gibi çeşitli ayarları içerir.

 ## PROJE ÜZERİNE
 Biz, yazılımcılar için bir ortaklık platformu oluşturmak için yola çıktık. Ekip arkadaşı arayan yazılımcıların projelerini tanıtabilmeleri için bir "gönderi mekanizması" oluşturduk. Böylece sitemiz aracılığıyla kendilerine ortak bulabileceklerdi. Amacımız, gönderiler üzerinden iletişim kurabilecekleri, profillerini düzenleyebilecekleri, sonuç odaklı, pratik bir site oluşturmaktı. \
 Frontend kısmında Anıl Berke Sağlam (180403021), Ahmed Tarık Üzümcü (180403013), Semih Kesgin (180403105); Backend kısmında Muhammed Bilal Benli (180403075), Başak Doğa Kaymaz (180403029) olmak üzere iki ekibe ayrılarak çalıştık.
 
 ## BACKEND ÜZERİNE
 ASP.NET Web API kullanarak MVC mimarisine uygun bir şekilde RESTful bir servis olarak geliştirdik. Her şeyi sıfırdan öğrenmeye başladığımız, oldukça dolu dolu geçen bir maceraydı. MongoDb ile çalışmayı öğrendik ve servislerin DevOPS kısmını inceleme fırsatı bulduk.\
 
   Projenin parçalarını inceleyecek olursak...
 - Veritabanı üzerindeki işlemleri (okuma, yazma, silme, güncelleme) gerçekleştiren katmanı Başak Doğa Kaymaz (180403029) geliştirdi.
 - Servise gelen istekleri cevaplayan controllerleri Muhammed Bilal Benli (180403075) geliştirdi.
 - Kimlik doğrulama üzerinde backend ekibi olarak çalıştık fakat çalışan bir versiyonunu hayata geçiremedik.
 - Kubernetes ve Docker teknolojilerini kullanarak projeyi AZURE üzerinde ayağa kaldırdık.
 - [Projenin swagger dökümantasyonuna ulaşmak için tıklayınız.](http://20.56.251.235/swagger/index.html)
 
 \ \
 
 CORS protokolünden ötürü dışarıdan gelen isteklere yanıt vermese de, proje, test ortamında sorunsuzca çalışıyor.
