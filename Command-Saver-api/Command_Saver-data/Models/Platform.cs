namespace Command_Saver_data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public virtual ICollection<CommandPlatform> Commands { get; set; } = new HashSet<CommandPlatform>();
    }
}
