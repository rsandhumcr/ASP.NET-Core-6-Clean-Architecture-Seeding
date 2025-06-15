using System.Text;

namespace CompanyNameSpace.ProjectName.Application.Utils;
public class LocalLogger
{
    public static void ExceptionLogger(Exception ex, string message, string filename)
    {
        var exceptionMessage = FormatException(ex);
        var wholeMessage = CreateMessageHeader(message, exceptionMessage);
        WriteStringToFile(filename, wholeMessage);
    }

    public static void MessageLogger(string message, string filename)
    {
        var wholeMessage = CreateMessageHeader(message, string.Empty);
        WriteStringToFile(filename, wholeMessage);
    }

    public static async Task ExceptionLoggerAsync(Exception ex, string message, string filename)
    {
        var exceptionMessage = FormatException(ex);
        var wholeMessage = CreateMessageHeader(message, exceptionMessage);
        await WriteStringToFileAsync(filename, wholeMessage);
    }


    public static async Task MessageLoggerAsync(string message, string filename)
    {
        var wholeMessage = CreateMessageHeader(message, string.Empty);
        await WriteStringToFileAsync(filename, wholeMessage);
    }

    private static string CreateMessageHeader(string message01, string message02)
    {
        var now = DateTime.Now;
        var sb = new StringBuilder($"--- {now:yyyy-MM-dd HH:mm:ss}\n");
        sb.AppendLine($"msg : {message01}");
        if (!string.IsNullOrWhiteSpace(message02))
            sb.AppendLine(message02);
        return sb.ToString();
    }

    public static string FormatException(Exception ex, int level = 0)
    {
        if (ex == null)
            return string.Empty;
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

    private static void WriteStringToFile(string filename, string textData)
    {
        var fullPath = GetFullPath(filename);
        if (File.Exists(fullPath))
            File.AppendAllText(fullPath, textData);
        else
            File.WriteAllText(fullPath, textData);
    }

    private static async Task WriteStringToFileAsync(string filename, string textData)
    {
        var fullPath = GetFullPath(filename);
        if (File.Exists(fullPath))
            await File.AppendAllTextAsync(fullPath, textData);
        else
            await File.WriteAllTextAsync(fullPath, textData);
    }

    private static string GetFullPath(string filename)
    {
        if (string.IsNullOrEmpty(filename))
            filename = "UserAppExceptionLog.txt";
        return Path.Combine(Path.GetTempPath(), filename);
    }

    public static void ExceptionLogger(Exception ex, string parameterData, string message, string filename)
    {
        var exceptionMessage = FormatException(ex);
        var wholeMessage = CreateMessageHeader(message + "\n" + parameterData, exceptionMessage);
        WriteStringToFile(filename, wholeMessage);
    }

    public static async Task ExceptionLoggerAsync(Exception ex, string parameterData, string message, string filename)
    {
        var exceptionMessage = FormatException(ex);
        var wholeMessage = CreateMessageHeader(message + "\n" + parameterData, exceptionMessage);
        await WriteStringToFileAsync(filename, wholeMessage);
    }
}
