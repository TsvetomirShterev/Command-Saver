namespace Command_Saver_service.DTO
{
    using Command_Saver_data.Models;

    public class ReadCommandModel
    {
        public int Id { get; set; }

        public string Goal { get; set; }

        public string Line { get; set; }

        public virtual ICollection<string> Platforms { get; set; } = new HashSet<string>();
    }
}
