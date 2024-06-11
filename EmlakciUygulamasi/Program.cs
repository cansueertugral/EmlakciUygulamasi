using EmlakciLib;

namespace EmlakciUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ev> evler = new List<Ev>();
            string secim;
            do
            {
                Console.WriteLine("Emlakcı Uygulamasına Hoşgeldiniz...");
                Console.WriteLine("Lütfen bir ev seçiniz:");
                Console.WriteLine("1-Kiralık Ev");
                Console.WriteLine("2-Satılık Ev");
                secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Ev kiralikEv = EvSecimi(evler, "kiralik");
                        evler.Add(kiralikEv);
                        break;
                    case "2":
                        Ev satilikEv = EvSecimi(evler, "satilik");
                        evler.Add(satilikEv);
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
                        break;
                }

                Console.Write("Tamam mı devam mı? (t/d)");
                secim = Console.ReadLine();
            } while (secim.ToLower() == "d");



            Kaydet(evler);
        }

        static Ev EvSecimi(List<Ev> evler, string tip)
        {
            Console.WriteLine("1- Kaydedilen ev bilgileri");
            Console.WriteLine("2- Yeni ev bilgisi gir");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                for (int i = 0; i < evler.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {evler[i]}");
                }

                Console.Write("Seçmek istediğiniz evin numarasını giriniz: ");
                int evNo= int.Parse(Console.ReadLine());

                if (evNo >= 1 && evNo <= evler.Count)
                {
                    return evler[evNo - 1];
                }
                else
                {
                    Console.WriteLine("Geçersiz numara! Yeni ev bilgisi giriliyor!");
                    return tip == "kiralik" ? KEvBilgileri() : SEvBilgileri();
                }
            }
            else
            {
                return tip == "kiralik" ? KEvBilgileri() : SEvBilgileri();
            }
        }

        static KiralikEv KEvBilgileri()
        {
            Console.WriteLine("Kiralık Ev Bilgileri Giriniz");
            KiralikEv kiralikEv = new KiralikEv();
            kiralikEv.OdaSayisi = BilgiAl<int>("Evin oda sayısı:");
            kiralikEv.KatNo = BilgiAl<int>("Evin Kat numarası:");
            kiralikEv.Alan = BilgiAl<int>("Evin Alanı:");
            kiralikEv.Kira = BilgiAl<float>("Evin Kirası:");
            kiralikEv.Depozito = BilgiAl<float>("Evin Depozitosu:");
            return kiralikEv;
        }

        static SatilikEv SEvBilgileri()
        {
            Console.WriteLine("Satılık Ev Bilgileri Giriniz");
            SatilikEv satilikEv = new SatilikEv();
            satilikEv.OdaSayisi = BilgiAl<int>("Evin oda sayısı:");
            satilikEv.KatNo = BilgiAl<int>("Evin Kat numarası:");
            satilikEv.Alan = BilgiAl<int>("Evin Alanı:");
            satilikEv.Fiyat = BilgiAl<float>("Evin Fiyatı:");
            return satilikEv;
        }

        static T BilgiAl<T>(string mesaj)
        {
            Console.Write(mesaj);
            string input = Console.ReadLine();
            return (T)Convert.ChangeType(input, typeof(T));
        }

        static void Kaydet(List<Ev> evler)
        {
            using (StreamWriter writerKiralik = new StreamWriter("kayitlievkiralik.txt"))
            using (StreamWriter writerSatilik = new StreamWriter("kayitlievsatilik.txt"))
            {
                foreach (var ev in evler)
                {
                    if (ev is KiralikEv)
                    {
                        writerKiralik.WriteLine(ev);
                    }
                    else if (ev is SatilikEv)
                    {
                        writerSatilik.WriteLine(ev);
                    }
                }
            }
            Console.WriteLine("Girilen Evlerin bilgileri dosyalara kaydedildi.");
        }
    }
}