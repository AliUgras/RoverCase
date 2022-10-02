using NasaProblemCase;

internal class Program
{
    #region Değişkenler
    static int platoSagUstX;
    static int platoSagUstY;
    static Rover rover;
    static string girilenVeri;
    static string[] girilenChar;
    static char[] hareketKomutlari;
    #endregion
    #region Constructor
    private static void Main(string[] args)
    {
        VeriIste();
    }
    #endregion
    #region Fonksiyonlar
    public static void VeriIste()  //Kullanıcıdan veriyi isteyip aldığımız verileri gerekli fonksiyonlara yönlendirerek istediğimiz sonuçları alabiliyoruz
    {
        Console.WriteLine("Lütfen platoya ait sağ üst nokta koordinatlarını giriniz: ");
        girilenVeri = Console.ReadLine();

        girilenChar = girilenVeri.Split(' ');

        platoSagUstX = Convert.ToInt32(girilenChar[0]);
        platoSagUstY = Convert.ToInt32(girilenChar[1]);

        do
        {
            Console.WriteLine("Lütfen roverin iniş konum bilgilerini giriniz: ");
            girilenVeri = Console.ReadLine();
            girilenChar = girilenVeri.Split(' '); //aldığımız stringi boşluklara göre charlara ayırmak için kullanılan fonksiyon

            rover = new Rover(Convert.ToInt32(girilenChar[0]), Convert.ToInt32(girilenChar[1]), char.Parse(girilenChar[2].ToUpper()));

            Console.WriteLine("Lütfen roverin hareket komutlarını giriniz: ");
            girilenVeri = Console.ReadLine().ToUpper();

            hareketKomutlari = girilenVeri.ToCharArray();//hareket komutunda boşluk olmadığından stringi direkt olarak char arraya dönüştürdüm

            rover.HareketEttir(hareketKomutlari);  //hareket komutlarını char array olarak hareket edilmesini sağlayan fonksiyona yolladım

            if (rover.KonumX > platoSagUstX || rover.KonumX < 0 || rover.KonumY > platoSagUstY || rover.KonumY < 0)
            {
                Console.WriteLine("Rover plato sınırları dışına çıktı!");
            }
            Console.WriteLine(rover.KonumX + " " + rover.KonumY + " " + (rover.Yon.ToString()).ToCharArray()[0]); //roverin konum ve yön bilgilerini sırayla ekrana yazıyorum
        } while (true);
    }
    #endregion
}