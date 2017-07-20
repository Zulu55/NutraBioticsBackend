namespace NutraBioticsBackend.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caráteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caráteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Index("User_Email_Index", IsUnique = true)]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caráteres")]
        public string Email { get; set; }

        [Display(Name = "Foto")]
        public string Picture { get; set; }

        [Display(Name = "Género")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, 2, ErrorMessage = "Ingrese 1 para Hombres y 2 para mujeres")]
        public int Gender { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "IMEI")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caráteres")]
        public string IMEI { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "El campo {0} debe tener entre {1} y {2} caráteres", MinimumLength = 5)]
        public string Password { get; set; }

        [JsonIgnore]
        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La contraseña y la confirmción con coincilan")]
        public string PasswordConfirm { get; set; }
    }
}