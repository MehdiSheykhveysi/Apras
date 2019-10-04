using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace App02.Contract.Contracts.FileHandeling
{
    public interface IFileHandler
    {
        Task<string> UploadFileAsync(IFormFile file, string PathToUploadFile, CancellationToken cancellationToken, string OldPath = null);
        void CreateImageThumb(string FilePathResizing, string SavePathAfterResize, int newWidth);
        void DeleteOldImageThumb(string ImageThumpPath, string Filename);
        Task<IFileOutPutInformation> GetThumonailFromVideoAsync(string VideoPath, string OutputPath, IFileOutPutInformation fileOutPutInformation, CancellationToken cancellationToken);
    }
}