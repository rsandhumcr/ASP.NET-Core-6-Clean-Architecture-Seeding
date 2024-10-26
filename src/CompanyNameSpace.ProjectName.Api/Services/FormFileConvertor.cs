using System.Text;
using CompanyNameSpace.ProjectName.Application.Models.FileUpload;

namespace CompanyNameSpace.ProjectName.Api.Services;

public interface IFormFileConvertor
{
    Task<IReadOnlyCollection<FileDataDto>> ConvertToFileData(List<IFormFile> files);
}

public class FormFileConvertor : IFormFileConvertor
{
    public async Task<IReadOnlyCollection<FileDataDto>> ConvertToFileData(List<IFormFile> files)
    {
        var fileList = new List<FileDataDto>();
        foreach (var formFile in files)
        {
            var fileDataSb = new StringBuilder();
            using (var reader = new StreamReader(formFile.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    fileDataSb.AppendLine(await reader.ReadLineAsync());
            }

            var fileData = new FileDataDto
            {
                FileName = formFile.FileName,
                Length = formFile.Length,
                Name = formFile.Name,
                Data = fileDataSb.ToString()
            };
            fileList.Add(fileData);
        }

        return fileList;
    }
}

public class TestIFileForm
{
    private IFormFile CreateTestFormFile(string fileName, string content)
    {
        var bytes = Encoding.UTF8.GetBytes(content);

        return new FormFile(
            new MemoryStream(bytes),
            0,
            bytes.Length,
            "Data",
            fileName
        );
    }
}