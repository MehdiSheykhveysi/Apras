using System.ComponentModel.DataAnnotations;

namespace App05.Bootstraper.Resources.Categories
{
    public class AddCategoryResource
    {
        [Required(ErrorMessage = "وارد کردن فیلد عنوان دسته بندی{Title} ضروری است")]
        [StringLength(maximumLength: 50, MinimumLength =3,ErrorMessage = "حداکثر طول برای فیلد عنوان {Title} تعداد 50 و حداقل 3 کاراکتر است")]
        public string Title { get; set; }
    }
}
