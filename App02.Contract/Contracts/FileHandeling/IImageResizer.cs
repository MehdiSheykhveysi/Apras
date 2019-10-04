namespace App02.Contract.Contracts.FileHandeling
{
    public interface IImageResizer
    {
        void Resizing(string FilePathResizing, string SavePathAfterResize, int newWidth);
    }
}