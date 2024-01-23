using System;
public static class Geometri
{
    // Nokta ve dikdörtgen çarpışma denetimi
    public static bool NoktaDikdortgenCarpismaDenetimi(double noktaX, double noktaY, double dortgenSolUstX, double dortgenSolUstY, double dortgenSagAltX, double dortgenSagAltY)
    {
        if (noktaX >= dortgenSolUstX && noktaX <= dortgenSagAltX && noktaY >= dortgenSolUstY && noktaY <= dortgenSagAltY)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Nokta ve çember çarpışma denetimi
    public static bool NoktaCemberCarpismaDenetimi(double noktaX, double noktaY, double cemberX, double cemberY, double cemberYaricap)
    {
        double uzaklik = Math.Sqrt(Math.Pow(noktaX - cemberX, 2) + Math.Pow(noktaY - cemberY, 2));
        if (uzaklik <= cemberYaricap)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool DortgenDortgenCarpismaDenetimi(double dortgen1SolUstX, double dortgen1SolUstY, double dortgen1SagAltX, double dortgen1SagAltY,
                                                      double dortgen2SolUstX, double dortgen2SolUstY, double dortgen2SagAltX, double dortgen2SagAltY)
    {
        // İlk dikdörtgenin köşe noktaları
        double dortgen1SolAltX = dortgen1SolUstX;
        double dortgen1SolAltY = dortgen1SagAltY;
        double dortgen1SagUstX = dortgen1SagAltX;
        double dortgen1SagUstY = dortgen1SolUstY;

        // İkinci dikdörtgenin köşe noktaları
        double dortgen2SolAltX = dortgen2SolUstX;
        double dortgen2SolAltY = dortgen2SagAltY;
        double dortgen2SagUstX = dortgen2SagAltX;
        double dortgen2SagUstY = dortgen2SolUstY;

        // Çarpışma durumunu kontrol etmek için gerekli şartlar
        bool solUstKosul = dortgen1SolUstX <= dortgen2SagUstX && dortgen1SolUstY <= dortgen2SagUstY;
        bool solAltKosul = dortgen1SolAltX <= dortgen2SagAltX && dortgen1SolAltY >= dortgen2SagAltY;
        bool sagUstKosul = dortgen1SagUstX >= dortgen2SolUstX && dortgen1SagUstY <= dortgen2SolUstY;
        bool sagAltKosul = dortgen1SagAltX >= dortgen2SolAltX && dortgen1SagAltY >= dortgen2SolAltY;

        // Dikdörtgenlerin birbirleriyle çarpışıp çarpışmadığının kontrolü
        if (solUstKosul && solAltKosul && sagUstKosul && sagAltKosul)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool CemberDikdortgenCarpismaDenetimi(double cemberX, double cemberY, double cemberYaricap, double dortgenSolUstX, double dortgenSolUstY, double dortgenSagAltX, double dortgenSagAltY)
    {
        // Çemberin merkezine en yakın dikdörtgen köşesi
        double x = cemberX;
        double y = cemberY;

        if (cemberX < dortgenSolUstX) // Çember dikdörtgenin solunda
        {
            x = dortgenSolUstX;
        }
        else if (cemberX > dortgenSagAltX) // Çember dikdörtgenin sağında
        {
            x = dortgenSagAltX;
        }

        if (cemberY < dortgenSolUstY) // Çember dikdörtgenin üstünde
        {
            y = dortgenSolUstY;
        }
        else if (cemberY > dortgenSagAltY) // Çember dikdörtgenin altında
        {
            y = dortgenSagAltY;
        }

        // Çemberin merkezi ve en yakın nokta arasındaki uzaklık
        double uzaklik = Math.Sqrt(Math.Pow(cemberX - x, 2) + Math.Pow(cemberY - y, 2));

        // Çember ve dikdörtgen çarpışıyor mu?
        if (uzaklik <= cemberYaricap)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Çember ve çember çarpışma denetimi
    public static bool CemberCemberCarpismaDenetimi(double cember1X, double cember1Y, double cember1Yaricap, double cember2X, double cember2Y, double cember2Yaricap)
    {
        double xFark = cember1X - cember2X;
        double yFark = cember1Y - cember2Y;
        double uzaklik = Math.Sqrt((xFark * xFark) + (yFark * yFark));

        if (uzaklik <= (cember1Yaricap + cember2Yaricap))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Nokta Küre çarpışma denetimi
    public static bool NoktaKureCarpismaDenetimi(double noktaX, double noktaY, double noktaZ, double kureX, double kureY, double kureZ, double kureYaricap)
    {
        double mesafeKare = Math.Pow(noktaX - kureX, 2) + Math.Pow(noktaY - kureY, 2) + Math.Pow(noktaZ - kureZ, 2);   // Burada çemberden ve diğer şekillerden farklı olarak x y koordinatları dışında Z koordinatı da bulunuyor çünkü küre 3 Boyutlu bir cisimdir ve bu çarpışmayı düzgün hesaplamak için Z koordinatını da hesaba katmak gerekiyor.
        double yaricapKare = Math.Pow(kureYaricap, 2);
        if (mesafeKare <= yaricapKare)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Nokta Küre çarpışma denetimi

    // Nokta-Dikdörtgen Prizma çarpışma denetimi
    public static bool NoktaDikdortgenPrizmaCarpismaDenetimi(double noktaX, double noktaY, double noktaZ, double prizmaX, double prizmaY, double prizmaZ, double prizmaGenislik, double prizmaYukseklik, double prizmaDerinlik)
    {
        if (noktaX < prizmaX || noktaX > prizmaX + prizmaGenislik)
        {
            return false;
        }
        if (noktaY < prizmaY || noktaY > prizmaY + prizmaYukseklik)
        {
            return false;
        }
        if (noktaZ < prizmaZ || noktaZ > prizmaZ + prizmaDerinlik)
        {
            return false;
        }
        return true;
    }
    //Nokta Dikdörtgen Prizma çarpışma denetimi


    // Nokta Sillindir Çarpışma Denetimi
    public static bool NoktaSilindirCarpismaDenetimi(double noktaX, double noktaY, double noktaZ, double silindirX, double silindirY, double silindirZ, double silindirYariCap, double silindirYukseklik)
    {
        // İlk olarak silindirin yüzeyinde mi yoksa içinde mi olduğunu kontrol ediyoruz
        if (noktaY > silindirY + silindirYukseklik || noktaY < silindirY)
        {
            return false;
        }

        // Dikey mesafeye bakıyoruz.
        double dikeyMesafe = noktaY - silindirY;

        // Noktanın silindirin yatayda çapıyla arasındaki mesafeyi hesaplıyoruz.
        double yatayMesafe = Math.Sqrt(Math.Pow(noktaX - silindirX, 2) + Math.Pow(noktaZ - silindirZ, 2));

        // Noktanın silindirin yarıçapından daha uzakta olup olmadığını kontrol ediyoruz.
        if (yatayMesafe > silindirYariCap)
        {
            return false;
        }

        // Noktanın silindirin üst ve alt yüzeyleri arasında mı olduğunu kontrol ediyoruz.
        if (dikeyMesafe >= 0 && dikeyMesafe <= silindirYukseklik)
        {
            return true;
        }

        // Yukarıdaki hiçbir koşulu sağlamıyorsa çarpışma yok demektir.
        return false;
    }
    // Nokta Silindir Çarpışma Denetimi


    // Silindir ile Silindir Çarpışma Denetimi
    public static bool SilindirSilindirCarpismaDenetimi(double silindir1X, double silindir1Y, double silindir1Z, double silindir1YariCap, double silindir1Yukseklik,
                                                         double silindir2X, double silindir2Y, double silindir2Z, double silindir2YariCap, double silindir2Yukseklik)
    {
        // İki silindirin yüzeylerinin birbirine en yakın mesafesi bulunur.
        double yatayMesafe = Math.Sqrt(Math.Pow(silindir2X - silindir1X, 2) + Math.Pow(silindir2Z - silindir1Z, 2));   //Math.Pow metodu bir sayının üstünü hesaplamaya olanak sağlar aldığı ilk ifade tabanı ikinci ifade ise üst kuvveti temsil eder.

        // İki silindirin dikey mesafesi bulunur.
        double dikeyMesafe = Math.Abs(silindir2Y - silindir1Y);    // Math.Abs ifadesi işlemin mutlak değerini alır işimizi kolaylaştırır.

        // İki silindirin yarıçaplarının toplamı bulunur.
        double yariCapToplam = silindir1YariCap + silindir2YariCap;

        // İki silindirin çarpışıp çarpışmadığı kontrol edilir.
        if (yatayMesafe <= yariCapToplam && dikeyMesafe <= silindir1Yukseklik + silindir2Yukseklik)
        {
            return true;
        }

        return false;
    }
    // Silindir-Silindir Çarpışma Denetimi


    //Küre-Küre Çarpışma Denetimi. 
    public static bool KureKureCarpismaDenetimi(double kure1X, double kure1Y, double kure1Z, double kure1YariCap, double kure2X, double kure2Y, double kure2Z, double kure2YariCap)
    {
        // İki kürenin merkezleri arasındaki mesafe hesaplanır.
        double mesafe = Math.Sqrt(Math.Pow(kure2X - kure1X, 2) + Math.Pow(kure2Y - kure1Y, 2) + Math.Pow(kure2Z - kure1Z, 2));

        // İki kürenin yarıçaplarının toplamı bulunur.
        double yariCapToplam = kure1YariCap + kure2YariCap;

        // İki kürenin çarpışıp çarpışmadığı kontrol edilir.
        if (mesafe <= yariCapToplam)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //Küre-Küre Çarpışma Denetimi. 



    //Küre-Silindir Çarpışma Denetimi.
    public static bool KureSilindirCarpismaDenetimi(double kureX, double kureY, double kureZ, double kureYariCap,
                                                    double silindirX, double silindirY, double silindirZ, double silindirYariCap, double silindirYukseklik)
    {
        // İki cismin yüzeylerinin birbirine en yakın mesafesi bulunur.
        double yatayMesafe = Math.Sqrt(Math.Pow(silindirX - kureX, 2) + Math.Pow(silindirZ - kureZ, 2));

        // İki cismin dikey mesafesi bulunur.
        double dikeyMesafe = Math.Abs(silindirY - kureY);

        // İki cismin yarıçaplarının toplamı bulunur.
        double yariCapToplam = kureYariCap + silindirYariCap;

        // İki cismin çarpışıp çarpışmadığı kontrol edilir.
        if (yatayMesafe <= yariCapToplam && dikeyMesafe <= silindirYukseklik + kureYariCap)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
    //Küre-Silindir Çarpışma Denetimi.

    //Yüzey-Küre Çarpışma Denetimi.
    public static bool YuzeyKureCarpismaDenetimi(double yuzeyX, double yuzeyY, double yuzeyZ, double yuzeyYukseklik, double yuzeyGenislik,
                                                 double kureX, double kureY, double kureZ, double kureYariCap)
    {
        // Kürenin merkez noktasının yüzeye olan mesafesi hesaplanır.
        double kureYuzeyeMesafe = Math.Abs(kureY - yuzeyY) - yuzeyYukseklik / 2.0;

        // Kürenin yüzeye olan en yakın mesafesi hesaplanır.
        double kureYuzeyeEnYakinMesafe = Math.Sqrt(Math.Pow(Math.Max(Math.Abs(kureX - yuzeyX) - yuzeyGenislik / 2.0, 0), 2) + Math.Pow(Math.Max(kureYuzeyeMesafe, 0), 2) + Math.Pow(Math.Max(Math.Abs(kureZ - yuzeyZ) - yuzeyGenislik / 2.0, 0), 2));

        // Kürenin yarıçapı ile yüzeyin yarıçapı toplamı karşılaştırılır.
        if (kureYuzeyeEnYakinMesafe <= kureYariCap)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
    //Yüzey-Küre Çarpışma Denetimi.


    //Yüzey-Dikdörtgen Prizma Çarpışma Denetimi.
    public static bool YuzeyDikdortgenPrizmaCarpismaDenetimi(double yuzeyX, double yuzeyY, double yuzeyZ, double yuzeyYukseklik, double yuzeyGenislik, double yuzeyDerinlik,
                                                             double prizmaX, double prizmaY, double prizmaZ, double prizmaYukseklik, double prizmaGenislik, double prizmaDerinlik)
    {
        // Prizmanın merkez noktasının yüzeye olan mesafesi hesaplanır.
        double prizmaYuzeyeMesafe = Math.Abs(prizmaY - yuzeyY) - yuzeyYukseklik / 2.0;

        // Prizmanın yüzeye olan en yakın mesafesi hesaplanır.
        double prizmaYuzeyeEnYakinMesafe = Math.Sqrt(Math.Pow(Math.Max(Math.Abs(prizmaX - yuzeyX) - yuzeyGenislik / 2.0, 0), 2) +
                                                    Math.Pow(Math.Max(prizmaYuzeyeMesafe, 0), 2) +
                                                    Math.Pow(Math.Max(Math.Abs(prizmaZ - yuzeyZ) - yuzeyDerinlik / 2.0, 0), 2));

        // Yüzeyin genişliği ve derinliği ile prizmanın genişliği ve derinliği toplamı karşılaştırılır.
        bool genislikCarpisma = (yuzeyGenislik / 2.0 + prizmaGenislik / 2.0) >= Math.Abs(prizmaX - yuzeyX);
        bool derinlikCarpisma = (yuzeyDerinlik / 2.0 + prizmaDerinlik / 2.0) >= Math.Abs(prizmaZ - yuzeyZ);
        bool yukseklikCarpisma = (yuzeyYukseklik / 2.0 + prizmaYukseklik / 2.0) >= Math.Abs(prizmaY - yuzeyY);

        // Yüzey ve prizmanın çarpışması kontrol edilir.
        if (prizmaYuzeyeEnYakinMesafe <= 0 && genislikCarpisma && derinlikCarpisma && yukseklikCarpisma)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
    //Yüzey-Dikdörtgen Prizma Çarpışma Denetimi.

    //Yüzey-Silindir Çarpışma Denetimi.

    public static bool YuzeySilindirCarpismaDenetimi(double yuzeyX, double yuzeyY, double yuzeyZ, double yuzeyYukseklik, double yuzeyGenislik, double yuzeyDerinlik,
                                                    double silindirX, double silindirY, double silindirZ, double silindirYukseklik, double silindirCap)
    {
        // Silindirin merkez noktasının yüzeye olan mesafesi hesaplanır.
        double silindirYuzeyeMesafe = Math.Abs(silindirY - yuzeyY) - yuzeyYukseklik / 2.0;

        // Silindirin yüzeye olan en yakın mesafesi hesaplanır.
        double silindirYuzeyeEnYakinMesafe = Math.Sqrt(Math.Pow(Math.Max(Math.Abs(silindirX - yuzeyX) - yuzeyGenislik / 2.0, 0), 2) +
                                                      Math.Pow(Math.Max(silindirYuzeyeMesafe, 0), 2) +
                                                      Math.Pow(Math.Max(Math.Abs(silindirZ - yuzeyZ) - yuzeyDerinlik / 2.0, 0), 2));

        // Yüzeyin genişliği, derinliği ve yüksekliği ile silindirin çapı ve yüksekliği toplamları karşılaştırılır.
        bool genislikCarpisma = (yuzeyGenislik / 2.0 + silindirCap) >= Math.Abs(silindirX - yuzeyX);
        bool derinlikCarpisma = (yuzeyDerinlik / 2.0 + silindirCap) >= Math.Abs(silindirZ - yuzeyZ);
        bool yukseklikCarpisma = (yuzeyYukseklik / 2.0 + silindirYukseklik / 2.0) >= Math.Abs(silindirY - yuzeyY);

        // Yüzey ve silindirin çarpışması kontrol edilir.
        if (silindirYuzeyeEnYakinMesafe <= 0 && genislikCarpisma && derinlikCarpisma && yukseklikCarpisma)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool KureDikdortgenCarpismaDenetimi(double kureX, double kureY, double kureZ, double kureCap,
                                                   double dikdortgenX, double dikdortgenY, double dikdortgenZ,
                                                   double dikdortgenYukseklik, double dikdortgenGenislik, double dikdortgenDerinlik)
    {
        // Kürenin ve dikdörtgenin merkez noktaları arasındaki mesafe hesaplanır.
        double mesafeX = Math.Abs(kureX - dikdortgenX);
        double mesafeY = Math.Abs(kureY - dikdortgenY);
        double mesafeZ = Math.Abs(kureZ - dikdortgenZ);

        // Dikdörtgen prizmanın kenar uzunluklarının yarısı hesaplanır.
        double yariGenislik = dikdortgenGenislik / 2.0;
        double yariDerinlik = dikdortgenDerinlik / 2.0;
        double yariYukseklik = dikdortgenYukseklik / 2.0;

        // Kürenin ve dikdörtgenin çarpışıp çarpışmadığı kontrol edilir.
        if (mesafeX > (yariGenislik + kureCap)) { return false; }
        if (mesafeY > (yariYukseklik + kureCap)) { return false; }
        if (mesafeZ > (yariDerinlik + kureCap)) { return false; }

        if (mesafeX <= yariGenislik) { return true; }
        if (mesafeY <= yariYukseklik) { return true; }
        if (mesafeZ <= yariDerinlik) { return true; }

        double kareX = Math.Pow(mesafeX - yariGenislik, 2);
        double kareY = Math.Pow(mesafeY - yariYukseklik, 2);
        double kareZ = Math.Pow(mesafeZ - yariDerinlik, 2);
        double mesafe = kareX + kareY + kareZ;

        return mesafe <= (kureCap * kureCap);
    }

    public static bool DikdortgenPrizmaCarpismaDenetimi(double prizma1X, double prizma1Y, double prizma1Z,
                                                    double prizma1Yukseklik, double prizma1Genislik, double prizma1Derinlik,
                                                    double prizma2X, double prizma2Y, double prizma2Z,
                                                    double prizma2Yukseklik, double prizma2Genislik, double prizma2Derinlik)
    {
        // İki prizmanın merkez noktaları arasındaki mesafe hesaplanır.
        double mesafeX = Math.Abs(prizma1X - prizma2X);
        double mesafeY = Math.Abs(prizma1Y - prizma2Y);
        double mesafeZ = Math.Abs(prizma1Z - prizma2Z);

        // Her prizmanın kenar uzunluklarının yarısı hesaplanır.
        double prizma1YariGenislik = prizma1Genislik / 2.0;
        double prizma1YariDerinlik = prizma1Derinlik / 2.0;
        double prizma1YariYukseklik = prizma1Yukseklik / 2.0;
        double prizma2YariGenislik = prizma2Genislik / 2.0;
        double prizma2YariDerinlik = prizma2Derinlik / 2.0;
        double prizma2YariYukseklik = prizma2Yukseklik / 2.0;

        // İki prizmanın çarpışıp çarpışmadığı kontrol edilir.
        if (mesafeX > (prizma1YariGenislik + prizma2YariGenislik)) { return false; }
        if (mesafeY > (prizma1YariYukseklik + prizma2YariYukseklik)) { return false; }
        if (mesafeZ > (prizma1YariDerinlik + prizma2YariDerinlik)) { return false; }

        return true;
    }



}

class Program
{
    static void Main(string[] args)
    {
        // Nokta-dikdörtgen çarpışma denetimi
        double noktaX = 4;
        double noktaY = 6;
        double noktaZ = 3;      // Sonrasında kullanılıcak şu andaki çarpışmalarda kullanılmayacak.
        double dortgenSolUstX = 2;
        double dortgenSolUstY = 8;
        double dortgenSagAltX = 8;
        double dortgenSagAltY = 12;

        bool carpisma = Geometri.NoktaDikdortgenCarpismaDenetimi(noktaX, noktaY, dortgenSolUstX, dortgenSolUstY, dortgenSagAltX, dortgenSagAltY);

        if (carpisma)
        {
            Console.WriteLine("Nokta ile dikdörtgen  çarpışıyor.");
        }
        else
        {
            Console.WriteLine("Nokta ile dikdörtgen çarpışmıyor.");
        }

        // Nokta-çember çarpışma denetimi
        double cemberX = 5;
        double cemberY = 5;
        double cemberYaricap = 3;

        carpisma = Geometri.NoktaCemberCarpismaDenetimi(noktaX, noktaY, cemberX, cemberY, cemberYaricap);

        if (carpisma)
        {
            Console.WriteLine("Nokta ile çember çarpışıyor.");
        }
        else
        {
            Console.WriteLine("Nokta ile çember çarpışmıyor.");
        }



        // İlk dikdörtgenin koordinatları
        double solUst1X = 3;
        double solUst1Y = 5;
        double sagAlt1X = 6;
        double sagAlt1Y = 2;

        // İkinci dikdörtgenin koordinatları
        double solUst2X = 5;
        double solUst2Y = 6;
        double sagAlt2X = 8;
        double sagAlt2Y = 3;

        // Dikdörtgenlerin çarpışma denetimi kontrolü
        bool dikdortgenDortgenCarpisiyorMu = Geometri.DortgenDortgenCarpismaDenetimi(solUst1X, solUst1Y, sagAlt1X, sagAlt1Y, solUst2X, solUst2Y, sagAlt2X, sagAlt2Y);

        // Çarpışma sonucunu ekrana yazdırma
        if (dikdortgenDortgenCarpisiyorMu)
        {
            Console.WriteLine("İki dikdörtgen çarpışıyor.");
        }
        else
        {
            Console.WriteLine("İki dikdörtgen çarpışmıyor.");
        }

        // Çemberin merkez koordinatları ve yarıçapı
        cemberX = 5;
        cemberY = 5;
        cemberYaricap = 3;

        // Dikdörtgenin koordinatları
        dortgenSolUstX = 2;
        dortgenSolUstY = 2;
        dortgenSagAltX = 8;
        dortgenSagAltY = 6;

        // Çarpışma denetimini yap
        carpisma = Geometri.CemberDikdortgenCarpismaDenetimi(cemberX, cemberY, cemberYaricap, dortgenSolUstX, dortgenSolUstY, dortgenSagAltX, dortgenSagAltY);

        // Çarpışma sonucuna göre çıktı ver
        if (carpisma)
        {
            Console.WriteLine("Çember ile dikdörtgen çarpışıyor.");
        }
        else
        {
            Console.WriteLine("Çember ile dikdörtgen çarpışmıyor.");
        }


        // Çemberin merkez koordinatları ve yarıçapı
        double cember1X = 5;
        double cember1Y = 5;
        double cember1Yaricap = 3;

        // İkinci çemberin merkez koordinatları ve yarıçapı
        double cember2X = 10;
        double cember2Y = 10;
        double cember2Yaricap = 2;

        // Çember çarpışma denetimini yap
        carpisma = Geometri.CemberCemberCarpismaDenetimi(cember1X, cember1Y, cember1Yaricap, cember2X, cember2Y, cember2Yaricap);

        // Çarpışma sonucuna göre çıktı ver
        if (carpisma)
        {
            Console.WriteLine("İki çember çarpışıyor.");
        }
        else
        {
            Console.WriteLine("İki çember çarpışmıyor.");
        }

        // Noktanın merkez koordinatları zaten ilk kısımlarda belirlemiştik tekrar belirlemeye gerek yok aynı noktayı kullanalım
        double kureX = 8;
        double kureY = 9;
        double kureZ = 5;
        double kureYaricap = 3;

        // Çarpışma Denetimi.
        carpisma = Geometri.NoktaKureCarpismaDenetimi(noktaX, noktaY, noktaZ, kureX, kureY, kureZ, kureYaricap);

        //Çarpışma sonucu ekrana çıktı çıkar.
        if (carpisma)
        {
            Console.WriteLine("Nokta ile Küre çarpışıyor.");
        }
        else
        {
            Console.WriteLine("Nokta ile Küre çarpışmıyor.");
        }

        //Noktanın koordinatlarını belirlemiştik yeni nokta oluşturmaya gerek yok.

        //Dikdörtgen prizmanın koordinatlarını ve boyutlarını belirle
        double prizmaX = 8;
        double prizmaY = 5;
        double prizmaZ = 2;
        double prizmaGenislik = 6;
        double prizmaYukseklik = 4;
        double prizmaDerinlik = 8;

        //Çarpışma denetimi
        carpisma = Geometri.NoktaDikdortgenPrizmaCarpismaDenetimi(noktaX, noktaY, noktaZ, prizmaX, prizmaY, prizmaZ, prizmaGenislik, prizmaYukseklik, prizmaDerinlik);

        //Çarpışma sonucu ekrana çıktı çıkar.
        if (carpisma)
        {
            Console.WriteLine("Nokta ile Dikdörtgen Prizma çarpışıyor.");
        }
        else
        {
            Console.WriteLine("Nokta ile Dikdörtgen Prizma çarpışmıyor.");
        }

        double silindirX = 1;
        double silindirY = 5;
        double silindirZ = 6;
        double silindirYariCap = 7;
        double silindirYukseklik = 8;

        // Çarpışma Denetimi
        carpisma = Geometri.NoktaSilindirCarpismaDenetimi(noktaX, noktaY, noktaZ, silindirX, silindirY, silindirZ, silindirYariCap, silindirYukseklik);

        // Çarpışma Sonucu Ekrana Çıktı Çıkarıcak Olan Bölüm.
        if (carpisma)
        {
            Console.WriteLine("Nokta ile silindir çarpışıyor.");
        }
        else
        {
            Console.WriteLine("Nokta ile silindir çarpışmıyor.");
        }


        // İki farklı silindirin koordinatlarını ve boyutlarını belirtelim.
        double silindir1X = 10;
        double silindir1Y = 7;
        double silindir1Z = 9;
        double silindir1YariCap = 4;
        double silindir1Yukseklik = 8;
        double silindir2X = 5;
        double silindir2Y = 4;
        double silindir2Z = 2;
        double silindir2YariCap = 3;
        double silindir2Yukseklik = 6;

        //Çarpışma Denetimi
        carpisma = Geometri.SilindirSilindirCarpismaDenetimi(silindir1X, silindir1Y, silindir1Z, silindir1YariCap, silindir1Yukseklik, silindir2X, silindir2Y, silindir2Z, silindir2YariCap, silindir2Yukseklik);

        //Çarpışma Sonucundan Gelen True veya False Değerini Ekrana Çarpıştı veya Çarpışmadı Değerini Bastıracak.
        if (carpisma)
        {
            Console.WriteLine("İki Silindir çarpışıyor.");
        }
        else
        {
            Console.WriteLine("İki Silindir çarpışmıyor.");
        }

        //Küre-Silindir Çarpışma Denetimi.

        // Kürelerin merkez koordinatları ve yarıçapıları atanır.
        double kure1X = 1;
        double kure1Y = 2;
        double kure1Z = 3;
        double kure1YariCap = 2;
        double kure2X = 4;
        double kure2Y = 5;
        double kure2Z = 6;
        double kure2YariCap = 2;

        // İki kürenin çarpışma denetimi yapılır.
        carpisma = Geometri.KureKureCarpismaDenetimi(kure1X, kure1Y, kure1Z, kure1YariCap, kure2X, kure2Y, kure2Z, kure2YariCap);

        //Çarpışma Sonucundan Gelen True veya False Değerini Ekrana Çarpıştı veya Çarpışmadı Değerini Bastıracak.
        if (carpisma)
        {
            Console.WriteLine("İki küre çarpışıyor.");
        }
        else
        {
            Console.WriteLine("İki küre çarpışmıyor.");
        }



        //Küre-Silindir Çarpışma Denetimi.

        //Küreyle Silindirin Koordinat Ve Büyüklükleri Zaten Tanımlanmışdı Tekrar Değiştirmeye Gerek Yok.
        carpisma = Geometri.KureSilindirCarpismaDenetimi(kureX, kureY, kureZ, kureYaricap, silindirX, silindirY, silindirZ, silindirYariCap, silindirYukseklik);

        if (carpisma)
        {
            Console.WriteLine("Küre ile Silindir çarpışıyor.");
        }
        else
        {
            Console.WriteLine("Küre ile Silindir çarpışmıyor.");
        }
        //Küre-Silindir Çarpışma Denetimi.


        // Yüzey-Küre Çarpışma Denetimi.
        double yuzeyX = 1;
        double yuzeyY = 0;
        double yuzeyZ = 0;
        double yuzeyYukseklik = 2;
        double yuzeyGenislik = 4;


        carpisma = Geometri.YuzeyKureCarpismaDenetimi(yuzeyX, yuzeyY, yuzeyZ, yuzeyYukseklik, yuzeyGenislik,
                                                      kureX, kureY, kureZ, kureYaricap);
        //Ekrana Çıktı Verir.
        if (carpisma)
        {
            Console.WriteLine("Yüzey ile Küre çarpışıyor.");
        }
        else
        {
            Console.WriteLine("Yüzey ile Küre çarpışmıyor.");
        }
        // Yüzey-Küre Çarpışma Denetimi.


        //Yüzey-Dikdörtgen Prizma Çarpışma Denetimi.
        // Yüzeyin ve Dikdörtgen Prizmanın Koordinatları ve Büyüklüklerini Önceden Belirlemiştik Gerek Yok Değiştirmeye.

        carpisma = Geometri.YuzeyDikdortgenPrizmaCarpismaDenetimi(yuzeyX, yuzeyY, yuzeyZ, yuzeyYukseklik, yuzeyGenislik, yuzeyGenislik,
                                                                  prizmaX, prizmaY, prizmaZ, prizmaYukseklik, prizmaGenislik, prizmaDerinlik);
        if (carpisma)
        {
            Console.WriteLine("Yüzey ile Dikdörtgen Prizma çarpışıyor.");
        }
        else
        {
            Console.WriteLine("Yüzey ile Dikdörtgen Prizma çarpışmıyor.");
        }
        //Yüzey-Dikdörtgen Prizma Çarpışma Denetimi.

        //Yüzey-Silindir Çarpışma Denetimi.

        yuzeyX = 1;
        yuzeyY = 2;
        yuzeyZ = 3;
        yuzeyYukseklik = 2;
        yuzeyGenislik = 4;
        double yuzeyDerinlik = 1;

        silindirX = 2;
        silindirY = 1;
        silindirZ = 3;
        silindirYukseklik = 5;
        double silindirCap = 6;

        carpisma = Geometri.YuzeySilindirCarpismaDenetimi(yuzeyX, yuzeyY, yuzeyZ, yuzeyYukseklik, yuzeyGenislik, yuzeyDerinlik,
                                                          silindirX, silindirY, silindirZ, silindirYukseklik, silindirCap);

        if (carpisma)
        {
            Console.WriteLine("Yüzey ile Silindir çarpışıyor.");
        }
        else
        {
            Console.WriteLine("Yüzey ile Silindir çarpışmıyor.");
        }
        //Yüzey-Silindir Çarpışma Denetimi

        //Küre-Dikdörtgen Prizma Çarpışma Denetimi

        kureX = 1;
        kureY = 0;
        kureZ = 2;
        double kureCap = 4;
        double dikdortgenX = 4;
        double dikdortgenY = 0;
        double dikdortgenZ = 3;
        double dikdortgenYukseklik = 7;
        double dikdortgenGenislik = 4;
        double dikdortgenDerinlik = 2;

        carpisma = Geometri.KureDikdortgenCarpismaDenetimi(kureX, kureY, kureZ, kureCap, dikdortgenX, dikdortgenY, dikdortgenZ, dikdortgenYukseklik, dikdortgenGenislik, dikdortgenDerinlik);

        if (carpisma)
        {
            Console.WriteLine("Küre ile Dikdörtgen Prizma çarpışıyor.");
        }
        else
        {
            Console.WriteLine("Küre ile Dikdörtgen Prizma çarpışmıyor.");
        }
        //Küre-Dikdörtgen Prizma Çarpışma Denetimi


        //İki tane Dikdörtgen Prizmanın Birbiriyle Çarpışma Denetimi

        double prizma1X = 0;
        double prizma1Y = 0;
        double prizma1Z = 0;
        double prizma1Yukseklik = 2;
        double prizma1Genislik = 1;
        double prizma1Derinlik = 3;

        double prizma2X = 5.0;
        double prizma2Y = 2.0;
        double prizma2Z = 3.0;
        double prizma2Yukseklik = 4.0;
        double prizma2Genislik = 2.0;
        double prizma2Derinlik = 3.0;

        carpisma = Geometri.DikdortgenPrizmaCarpismaDenetimi(prizma1X, prizma1Y, prizma1Z, prizma1Yukseklik, prizma1Genislik, prizma1Derinlik, prizma2X, prizma2Y, prizma2Z, prizma2Yukseklik, prizma2Genislik, prizma2Derinlik);

        if (carpisma)
        {
            Console.WriteLine("Dikdörtgen Prizmalar Birbiriyle çarpışıyor.");
        }
        else
        {
            Console.WriteLine("Dikdörtgen Prizmalar Birbiriyle çarpışmıyor.");
        }

        //İki tane Dikdörtgen Prizmanın Birbiriyle Çarpışma Denetimi

        Console.ReadKey();
    }
}