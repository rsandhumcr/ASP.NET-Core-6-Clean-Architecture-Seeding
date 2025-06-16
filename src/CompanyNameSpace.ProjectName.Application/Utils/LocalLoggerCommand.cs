using System.Text;
using System.Text.Json;

namespace CompanyNameSpace.ProjectName.Application.Utils;
public class LocalLoggerCommand
{
    private const string DefaultStringName = "UserAppException.log";
    private readonly string _fileName;
    private string _message;

    private LocalLoggerCommand(string fileName)
    {
        _fileName = fileName;
    }

    public static LocalLoggerCommand NewMsg() => new LocalLoggerCommand(DefaultStringName);
    
    public static LocalLoggerCommand NewMsg(string filename) => new LocalLoggerCommand(filename);
    
    public LocalLoggerCommand AddMessage(params string[] values)
    {
        var sb = new StringBuilder();
        foreach (var value in values)
            sb.Append(value);
        _message += sb.ToString();
        return this;
    }

    public LocalLoggerCommand AddMessageLines(params string[] values)
    {
        var sb = new StringBuilder();
        foreach (var value in values)
            sb.AppendLine(value);
        _message += sb.ToString();
        return this;
    }

    public LocalLoggerCommand AddValueParameter(string parameterName, string dataValue)
    {
        _message += "\n" + parameterName + ": " + dataValue;
        return this;
    }

    public LocalLoggerCommand AddObjectParameter(string parameterName, Object obj)
    {
        _message += parameterName +": " + ConvertToJson(obj);
        return this;
    }

    public LocalLoggerCommand AddException(Exception ex)
    {
        _message += "\n" + FormatException(ex, 0);
        return this;
    }

    public void WriteToLog() => WriteStringToFile(_fileName, _message);
    
    public async Task WriteToLogAsync() => await WriteStringToFileAsync(_fileName, _message);

    private string FormatException(Exception ex, int level = 0)
    {
        if (ex == null)
            return string.Empty;
        var sb = new StringBuilder();
        sb.AppendLine($"level {level}");
        sb.AppendLine("==========");
        sb.AppendLine($"Message: {ex.Message}");
        sb.AppendLine($"Source: {ex.Source}");
        sb.AppendLine($"Stack: {ex.StackTrace}");
        if (ex.InnerException != null)
            sb.AppendLine(FormatException(ex.InnerException, level + 1));
        return sb.ToString();
    }

    private static void WriteStringToFile(string filename, string textData)
    {
        var fullPath = GetFullPath(filename);
        if (File.Exists(fullPath))
            File.AppendAllText(fullPath, textData);
        else
            File.WriteAllText(fullPath, textData);
    }
    
    private async Task WriteStringToFileAsync(string filename, string textData)
    {
        var fullPath = GetFullPath(filename);
        if (File.Exists(fullPath))
            await File.AppendAllTextAsync(fullPath, textData);
        else
            await File.WriteAllTextAsync(fullPath, textData);
    }

    private static string GetFullPath(string filename) => Path.Combine(Path.GetTempPath(), filename);

    private string ConvertToJson(object objectItem)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        return JsonSerializer.Serialize(objectItem, options);
    }
}

