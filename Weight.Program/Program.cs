using Weight.Program.WeightDatabase.Tables;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace Weight.Program;

public class Program
{
    //public static T ReadCVS<T>(T )
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        var csvPath = @".\..\..\..\CSVs\ControlWeighingSetting.csv";
        using var reader = new StreamReader(csvPath, Encoding.UTF8);
        var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";"
        };
        
        using var csv = new CsvReader(reader, csvConfig);

        csv.Context.TypeConverterCache.AddConverter<int?>(new CustomCvsConverter<int>());
        csv.Context.TypeConverterCache.AddConverter<DateTime?>(new CustomCvsConverter<DateTime>());
        csv.Context.TypeConverterCache.AddConverter<double?>(new CustomCvsConverter<double>());

        var records = csv.GetRecords<ControlWeighingSetting>().ToList();
        foreach (var x in records )
        {
            Console.WriteLine($"{x.Id}");
        }
    }
}