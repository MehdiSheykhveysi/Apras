using System.Threading;
using System.Threading.Tasks;
using App00.Common.Attributes;
using App02.Contract.Contracts.FileHandeling;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace App03.AppService.Concretes.FileHandeling
{
    [ServiceMark]
    public class FileWriter : IFileWriter
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IImageResizer imageResizer;
        private readonly IFileHelper fileHelper;

        public FileWriter(IHostingEnvironment HostingEnvironment, IImageResizer ImageResizer, IFileHelper FileHelper)
        {
            this.hostingEnvironment = HostingEnvironment;
            this.imageResizer = ImageResizer;
            this.fileHelper = FileHelper;
        }
        /// <summary>
        /// Copy Image In Your specified Path By Using File 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="PathToUploadFile">New Path For Upload File in </param>
        /// <param name="cancellationToken"></param>
        /// <param name="OldPath">Old Path For Delete Old File . Default Id Null</param>
        /// <returns></returns>
        public async Task<string> UploadFileAsync(IFormFile file, string PathToUploadFile, CancellationToken cancellationToken, string OldPath = null)
        {
            string strFilePath = await fileHelper.SaveFileAsync(file, PathToUploadFile, cancellationToken, OldPath);
            strFilePath = strFilePath
                .Replace(PathToUploadFile, string.Empty)
                .Replace("\\", string.Empty);//Relative Path can be stored in database or do logically what is needed.
            return strFilePath;
        }

        public void CreateImageThumb(string FilePathResizing, string SavePathAfterResize, int newWidth)
        {
            imageResizer.Resizing(FilePathResizing, SavePathAfterResize, newWidth);
        }

        public void DeleteOldImageThumb(string ImageThumppath, string Filename)
        {
            fileHelper.DeleteOldFile(ImageThumppath, Filename);
        }

        public async Task<IFileOutPutInformation> GetThumonailFromVideoAsync(string VideoPath, string OutputPath, IFileOutPutInformation fileInformation, CancellationToken cancellationToken)
        {
            return await fileHelper.GetThumonailFromVideoAsync(VideoPath, OutputPath, fileInformation, cancellationToken);
        }
    }
}