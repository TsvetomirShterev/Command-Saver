namespace Command_Saver_service.DTO
{
    public class ReadPlatformModel
    {
        public string Name { get; set; }

        public virtual ICollection<string> Commands { get; set; } = new List<string>();
    }
}
