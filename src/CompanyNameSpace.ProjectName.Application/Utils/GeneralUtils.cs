using System.Diagnostics;
using System.Text;

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
}