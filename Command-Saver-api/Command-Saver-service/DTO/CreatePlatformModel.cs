namespace Command_Saver_service.DTO
{
    using Command_Saver_data.Models;
    using System.ComponentModel.DataAnnotations;

    public class CreatePlatformModel
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

    }
}
