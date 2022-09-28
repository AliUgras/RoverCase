using NasaProblemCase;

internal class Program
{
    #region Değişkenler
    static List<Rover> roverlar = new List<Rover>();
    static Rover rover;
    static int roverSayisi;
    static string girilenVeri;
    static string[] girilenChar;
    static char[] hareketKomutlari;
    #endregion
    #region Constructor
    private static void Main(string[] args)
    {
        VeriIste();
        VeriYaz();
    }
    #endregion
    #region Fonksiyonlar
    public static void RKomut(Rover rover)
    {
        switch (rover.Yon)
        {
            case 'N':
                rover.Yon = 'E';
                break;
            case 'W':
                rover.Yon = 'N';
                break;
            case 'E':
                rover.Yon = 'S';
                break;
            case 'S':
                rover.Yon = 'W';
                break;
        }
    }
    public static void LKomut(Rover rover)
    {
        switch (rover.Yon)
        {
            case 'N':
                rover.Yon = 'W';
                break;
            case 'W':
                rover.Yon = 'S';
                break;
            case 'E':
                rover.Yon = 'N';
                break;
            case 'S':
                rover.Yon = 'E';
                break;
        }
    }
    public static void MKomut(Rover rover)
    {
        switch (rover.Yon)
        {
            case 'N':
                rover.KonumY++;
                break;
            case 'W':
                rover.KonumX--;
                break;
            case 'E':
                rover.KonumX++;
                break;
            case 'S':
                rover.KonumY--;
                break;
        }
    }
    public static void VeriIste()
    {
        Console.WriteLine("Lütfen platoya ait sağ üst nokta koordinatlarını giriniz: ");
        girilenVeri = Console.ReadLine();

        girilenChar = girilenVeri.Split(' ');

        Console.WriteLine("Lütfen iniş yapan rover sayısını giriniz: ");
        roverSayisi = Convert.ToInt32(Console.ReadLine());

        for(int i=0; i < roverSayisi; i++)
        {
            Console.WriteLine("Lütfen " + (i + 1) + ". roverin iniş konum bilgilerini giriniz: ");
            girilenVeri = Console.ReadLine();
            girilenChar = girilenVeri.Split(' ');

            rover = new Rover()
            {
                KonumX = Convert.ToInt32(girilenChar[0]),
                KonumY = Convert.ToInt32(girilenChar[1]),
                Yon = char.Parse(girilenChar[2].ToUpper())
            };

            Console.WriteLine("Lütfen " + (i + 1) + ". roverin hareket komutlarını giriniz: ");
            girilenVeri = Console.ReadLine().ToUpper();
            hareketKomutlari = girilenVeri.ToCharArray();
            foreach(char x in hareketKomutlari)
            {
                switch (x)
                {
                    case 'L':
                        LKomut(rover);
                        break;
                    case 'R':
                        RKomut(rover);
                        break;
                    case 'M':
                        MKomut(rover);
                        break;
                }
            }

            roverlar.Add(rover);
        }
    }
    public static void VeriYaz()
    {
        foreach(Rover rover in roverlar)
        {
            Console.WriteLine(rover.KonumX + " " + rover.KonumY + " " + rover.Yon);
        }
    }
    #endregion
}