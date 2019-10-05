using System.ComponentModel.DataAnnotations;
namespace App05.Bootstraper.Resources.Posters
{
    public class AddPosterResource
    {
        [Required(ErrorMessage = "افزودن نام اگهی(Title) الزامی است")]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "حداکثر طول 100 و حداقل 3 کاراکتر برای (Title) الزامی است")]
        public string Title { get; set; }

        [Required(ErrorMessage = "افزودن توضیحات آگهی (Description) الزامی است")]
        [StringLength(maximumLength: 250, MinimumLength = 3, ErrorMessage = "حداکثر طول 250 و حداقل 3 کاراکتر الزامی (Description) است")]
        public string Description { get; set; }

        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "حداکثر طول 11 و حداقل 11 کاراکتر الزامی برای (PhoneNumber) است")]
        public string PhoneNumber { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "حداکثر طول 100 و حداقل 3 کاراکتر الزامی برای (WebSiteAddress) است")]
        public string WebSiteAddress { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "حداکثر طول 50 و حداقل 3 کاراکتر الزامی برای (Email) است")]
        public string Email { get; set; }

        [Required(ErrorMessage ="انتخاب یک استان اجباری است")]
        [RegularExpression("([0-9]+)", ErrorMessage = "لطفا مقدار استان انتخاب شده را در قالب صحیح (عدد صحیح)ارسال نمایید")]
        public int ProvinceId { get; set; }

        [Required(ErrorMessage = "انتخاب یک دسته بندی اجباری است")]
        [RegularExpression("([0-9]+)", ErrorMessage = "لطفا مقدار دسته بندی انتخاب شده را در قالب صحیح (عدد صحیح)ارسال نمایید")]
        public int CategoryID { get; set; }
    }
}