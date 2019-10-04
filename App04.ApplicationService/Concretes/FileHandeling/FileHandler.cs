using App00.Common.Attributes;
using App02.Contract.Contracts.FileHandeling;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace App03.AppService.Concretes.FileHandeling
{
    [ServiceMark]
    public class FileHandler : IFileHandler
    {
        private readonly IFileWriter fileWriter;
        public FileHandler(IFileWriter fileWriter)
        {
            this.fileWriter = fileWriter;
        }

        public void CreateImageThumb(string FilePathResizing, string SavePathAfterResize, int newWidth)
        {
            fileWriter.CreateImageThumb(FilePathResizing, SavePathAfterResize, newWidth);
        }

        public void DeleteOldImageThumb(string ImageThumpPath, string Filename)
        {
            fileWriter.DeleteOldImageThumb(ImageThumpPath, Filename);
        }

        public async Task<IFileOutPutInformation> GetThumonailFromVideoAsync(string VideoPath, string OutputPath, IFileOutPutInformation fileOutPutInformation, CancellationToken cancellationToken)
        {
            return await fileWriter.GetThumonailFromVideoAsync(VideoPath, OutputPath,fileOutPutInformation, cancellationToken);
        }

        public async Task<string> UploadFileAsync(IFormFile file, string PathToUploadFile, CancellationToken cancellationToken, string OldPath = null)
        {
            return await fileWriter.UploadFileAsync(file, PathToUploadFile, cancellationToken, OldPath);
        }
    }
}
