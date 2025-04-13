using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        CovidConfig config = new CovidConfig();

        // Ubah satuan suhu
        config.UbahSatuan();
        Console.WriteLine($"Satuan suhu diubah menjadi: {config.satuan_suhu}");

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        double suhu = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hariDemam = Convert.ToInt32(Console.ReadLine());

        bool isSuhuNormal = false;

        if (config.satuan_suhu.ToLower() == "celcius")
        {
            if (suhu >= 36.5 && suhu <= 37.5)
            {
                isSuhuNormal = true;
            }
        }
        else if (config.satuan_suhu.ToLower() == "fahrenheit")
        {
            if (suhu >= 97.7 && suhu <= 99.5)
            {
                isSuhuNormal = true;
            }
        }

        if (isSuhuNormal && hariDemam < config.batas_hari_deman)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }
    }
}
