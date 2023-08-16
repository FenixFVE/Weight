using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Weight.Program.CSV;

public sealed class CustomCvsConverter<T> : DefaultTypeConverter
{
    public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrEmpty(text) || text.Equals("NULL", StringComparison.OrdinalIgnoreCase))
            return null;

        if (typeof(T) == typeof(int))
            return int.TryParse(text, out int result) ? result : null;

        if (typeof(T) == typeof(double))
            return double.TryParse(text, out double result) ? result : null;

        if (typeof(T) == typeof(DateTime))
            return DateTime.TryParse(text, out DateTime result) ? result : null;

        return base.ConvertFromString(text, row, memberMapData);
    }
}
