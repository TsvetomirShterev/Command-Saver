namespace Command_Saver_data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Command
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Goal { get; set; }

        [Required]
        [MaxLength(255)]
        public string Line { get; set; }

        public virtual ICollection<CommandPlatform> Platforms { get; set; } = new HashSet<CommandPlatform>();
    }
}
