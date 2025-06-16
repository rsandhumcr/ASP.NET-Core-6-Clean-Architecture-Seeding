using System.Text;
using System.Text.Json;

namespace CompanyNameSpace.ProjectName.Application.Utils;
public class LocalLoggerCommand
{
    private string FileName = "UserAppException.log";
    private string message;

    public LocalLoggerCommand()
    {
    }

    public LocalLoggerCommand(string fileName)
    {
        FileName = fileName;
    }

    public static LocalLoggerCommand NewMsg()
    {
        return new LocalLoggerCommand();
    }

    public static LocalLoggerCommand NewMsg(string filename)
    {
        return new LocalLoggerCommand(filename);
    }


    public LocalLoggerCommand AddMessage(params string[] values)
    {
        var sb = new StringBuilder();
        foreach (var value in values)
            sb.Append(value);
        message += sb.ToString();
        return this;
    }

    public LocalLoggerCommand AddMessageLine(params string[] values)
    {
        var sb = new StringBuilder();
        foreach (var value in values)
            sb.AppendLine(value);
        message += sb.ToString();
        return this;
    }

    public LocalLoggerCommand AddValueParameter(string parameterName, string dataValue)
    {
        message += parameterName + ": " + dataValue + "\n";
        return this;
    }

    public LocalLoggerCommand AddObjectParameter(string parameterName, Object obj)
    {
        message += parameterName + ": " + ConvertToJson(obj) + "\n";
        return this;
    }

    public LocalLoggerCommand AddException(Exception ex)
    {
        message += "\n" + FormatException(ex, 0);
        return this;
    }

    public void WriteToLog()
    {
        WriteStringToFile(FileName, message);
    }

    public async Task WriteToLogAsync()
    {
        await WriteStringToFileAsync(FileName, message);
    }

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

    private static string GetFullPath(string filename)
    {
        return Path.Combine(Path.GetTempPath(), filename);
    }

    private string ConvertToJson(object objectItem)
    {
        return JsonSerializer.Serialize(objectItem);
    }
}

