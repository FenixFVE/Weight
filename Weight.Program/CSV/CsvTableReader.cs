using Weight.Program.WeightDatabase.Tables;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace Weight.Program.CSV;

public sealed class CsvTableReader
{
    public static List<T> Read<T>(string csvFilePath) where T : BaseTable
    {
        if (!File.Exists(csvFilePath))
            throw new FileNotFoundException(csvFilePath);

        using var reader = new StreamReader(csvFilePath, Encoding.Default);

        var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";"
        };

        using var csv = new CsvReader(reader, csvConfig);

        csv.Context.TypeConverterCache.AddConverter<int?>(new CustomCvsConverter<int>());
        csv.Context.TypeConverterCache.AddConverter<DateTime?>(new CustomCvsConverter<DateTime>());
        csv.Context.TypeConverterCache.AddConverter<double?>(new CustomCvsConverter<double>());

        var records = csv.GetRecords<T>().ToList();

        return records;
    }

    public static List<T> Read<T>() where T : BaseTable
    {
        var path = $@"{AppDomain.CurrentDomain.BaseDirectory}\..\..\..\CSV\Data\{typeof(T).Name}.csv";
        return Read<T>(path).ToList();
    }

    public static IAsyncEnumerable<T> ReadAsync<T>(string csvFilePath) where T : BaseTable
    {
        if (!File.Exists(csvFilePath))
            throw new FileNotFoundException(csvFilePath);

        using var reader = new StreamReader(csvFilePath, Encoding.Default);

        var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";"
        };

        using var csv = new CsvReader(reader, csvConfig);

        csv.Context.TypeConverterCache.AddConverter<int?>(new CustomCvsConverter<int>());
        csv.Context.TypeConverterCache.AddConverter<DateTime?>(new CustomCvsConverter<DateTime>());
        csv.Context.TypeConverterCache.AddConverter<double?>(new CustomCvsConverter<double>());

        var records = csv.GetRecordsAsync<T>();

        return records;
    }

    public static IAsyncEnumerable<T> ReadAsync<T>() where T : BaseTable
    {
        var path = $@"{AppDomain.CurrentDomain.BaseDirectory}\..\..\..\CSV\Data\{typeof(T).Name}.csv";
        return ReadAsync<T>(path);
    }
}
