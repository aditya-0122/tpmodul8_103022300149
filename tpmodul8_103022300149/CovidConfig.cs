using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

public class CovidConfig
{
    [JsonProperty("satuan_suhu")]
    public string satuan_suhu { get; set; }
    public int batas_hari_deman { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }

    private static string configPath = "covid_config.json";

    public CovidConfig()
    {
        if (File.Exists(configPath))
        {
            string json = File.ReadAllText(configPath);
            var config = JsonConvert.DeserializeObject<CovidConfig>(json);
            satuan_suhu = config.satuan_suhu;
            batas_hari_deman = config.batas_hari_deman;
            pesan_ditolak = config.pesan_ditolak;
            pesan_diterima = config.pesan_diterima;
        }
        else
        {
            // Default value
            satuan_suhu = "celcius";
            batas_hari_deman = 14;
            pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

            SaveConfig();
        }
    }

    public void SaveConfig()
    {
        var json = JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented); // Fully qualify Formatting
        File.WriteAllText(configPath, json);
    }

    public void UbahSatuan()
    {
        if (satuan_suhu?.ToLower() == "celcius")
        {
            satuan_suhu = "fahrenheit";
        }
        else if (satuan_suhu?.ToLower() == "fahrenheit")
        {
            satuan_suhu = "celcius";
        }
        else
        {
            throw new InvalidOperationException("Satuan suhu tidak valid.");
        }

        SaveConfig();
    }
}
