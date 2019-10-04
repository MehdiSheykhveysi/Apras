using App02.Contract.Contracts.DTOs;

namespace App03.Infrastructure.DB.DTOs
{
    public class PosterPagedDto : IPosterPagedDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string WebSiteAddress { get; set; }
        public string Email { get; set; }
    }
}
