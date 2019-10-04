using FFmpeg.NET;

namespace App02.Contract.Contracts.FileHandeling
{
    public interface IFileOutPutInformation
    {
        MediaFile MediaFile { get; set; }
        MetaData MetaData { get; set; }
    }
}
