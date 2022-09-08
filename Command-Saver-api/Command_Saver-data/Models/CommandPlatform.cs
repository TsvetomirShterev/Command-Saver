namespace Command_Saver_data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class CommandPlatform
    {
        [ForeignKey(nameof(Command))]
        public int CommandId { get; set; }

        public virtual Command Command { get; set; }

        [ForeignKey(nameof(Platform))]
        public int PlatformId { get; set; }

        public virtual Platform Platform { get; set; }
    }
}
