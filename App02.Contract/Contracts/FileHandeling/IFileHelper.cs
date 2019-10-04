using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace App02.Contract.Contracts.FileHandeling
{
    public interface IFileHelper
    {
        bool CheckIfImageFile(IFormFile file);
        void DeleteOldFile(string OldProfileImageFile, string FileName);
        string GetFileExtension(IFormFile file);
        string GetFileNameFromPath(string Path);
        Task<IFileOutPutInformation> GetThumonailFromVideoAsync(string VideoPath, string OutputPath, IFileOutPutInformation fileOutPutInformation, CancellationToken cancellationToken);
        string GetUniqueName(string preFix);
        string SaveFile(IFormFile file, string pathToUplaod, string OldProfileImagePath);
        Task<string> SaveFileAsync(IFormFile file, string pathToUplaod, CancellationToken cancellationToken, string OldProfileImagePath = null);
        string SetFileName(IFormFile file);
    }
}