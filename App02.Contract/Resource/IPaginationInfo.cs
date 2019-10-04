namespace App02.Contract.Resource
{
    public interface IPaginationInfo
    {
        int PageNumber { get; set; }
        int PageSize { get; }
    }
}
