using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace CompanyNameSpace.ProjectName.Application.Utils;

public class GeneralUtils
{
    public static string FormatException(Exception ex, int level = 0)
    {
        var sb = new StringBuilder();
        sb.AppendLine(string.Empty);
        sb.AppendLine($"level {level}");
        sb.AppendLine("==========");
        sb.AppendLine($"Message: {ex.Message}");
        sb.AppendLine($"Source: {ex.Source}");
        sb.AppendLine($"Stack: {ex.StackTrace}");
        if (ex.InnerException != null)
            sb.AppendLine(FormatException(ex.InnerException, level + 1));
        return sb.ToString();
    }

    public static void DebugWriteLineException(Exception ex)
    {
        var error = FormatException(ex);
        Debug.WriteLine(error);
    }
    public static void ConsoleWriteLineException(Exception ex)
    {
        var error = FormatException(ex);
        Console.WriteLine(error);
    }
    
    public static T? ConvertToObject<T>(string jsonData)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        return JsonSerializer.Deserialize<T>(jsonData, options);
    }

    public static string ConvertToJson(object objectItem)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        return JsonSerializer.Serialize(objectItem, options);
    }


    public static List<T> ConvertJsonData<T>(List<string> dataList)
    {
        var listObjectData = new List<T>();

        foreach (var stringData in dataList)
        {
            var data = ConvertToObject<T>(stringData);
            if (data != null) listObjectData.Add(data);
        }

        return listObjectData;
    }
}