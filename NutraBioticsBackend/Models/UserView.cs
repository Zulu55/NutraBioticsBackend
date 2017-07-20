namespace NutraBioticsBackend.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    [NotMapped]
    public class UserView : User
    {
        [Display(Name = "Foto")]
        public HttpPostedFileBase PictureFile { get; set; }    }
}