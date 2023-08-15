using Microsoft.Identity.Client;
using Weight.Program.WeightDatabase;
using Weight.Program.WeightDatabase.Configurations;
using Weight.Program.WeightDatabase.Tables;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Globalization;
using System.Text;
using CsvHelper.TypeConversion;
using System.Reflection;

namespace Weight.Program;

public class CustomCvsConverter<T>: DefaultTypeConverter
{
    public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        if(string.IsNullOrEmpty(text) || text.Equals("NULL", StringComparison.OrdinalIgnoreCase)) 
            return null;

        if (typeof(T) == typeof(int))
            return int.TryParse(text, out int result) ? result : null;

        if (typeof(T) == typeof(double))
            return double.TryParse(text, out  double result) ? result : null;

        if (typeof(T) == typeof(DateTime))
            return DateTime.TryParse(text, out DateTime result) ? result : null;

        return base.ConvertFromString(text, row, memberMapData);
    }
}

//[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
//public sealed class CsvIgnoreHeader : Attribute
//{
//}

public sealed class WeightSettingMap : ClassMap<WeightSetting>
{
    public WeightSettingMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
        Map(m => m.Department).Ignore();
    }
}

public class Program
{
    //public static T ReadCVS<T>(T )
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        var csvPath = @".\..\..\..\CSVs\WeightSetting.csv";
        using var reader = new StreamReader(csvPath, Encoding.UTF8);
        var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";"
        };
        
        using var csv = new CsvReader(reader, csvConfig);

        csv.Context.TypeConverterCache.AddConverter<int?>(new CustomCvsConverter<int>());
        csv.Context.TypeConverterCache.AddConverter<DateTime?>(new CustomCvsConverter<DateTime>());
        csv.Context.TypeConverterCache.AddConverter<double?>(new CustomCvsConverter<double>());

        csv.Context.RegisterClassMap<WeightSettingMap>();

        var records = csv.GetRecords<WeightSetting>().ToList();
        foreach (var x in records )
        {
            Console.WriteLine($"{x.Id}");
        }
    }
}