namespace App02.Contract.Contracts.DTOs
{
    public interface IPosterPagedDto
    {
        string Description { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string Title { get; set; }
        string WebSiteAddress { get; set; }
    }
}