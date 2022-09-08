namespace Command_Saver_service.DTO
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateCommandModel
    {
        [Required]
        [MaxLength(100)]
        public string Goal { get; set; }

        [Required]
        [MaxLength(255)]
        public string Line { get; set; }

        public virtual ICollection<string> Platforms { get; set; } = new HashSet<string>();
    }
}
