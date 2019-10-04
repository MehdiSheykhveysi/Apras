using App02.Contract.Resource;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace App05.Bootstraper.Resources
{
    public class PaginationInfo : IPaginationInfo
    {

        public int PageNumber { get; set; }
        [BindNever]
        public int PageSize => 3;
        public string SerackKeyInTitle { get; set; }
    }
}
