namespace Command_Saver_data.Queries
{
    using Command_Saver_data.Models;

    public interface ICommandQueries
    {
        public ICollection<Command> GetAllCommands();

        public Command GetCommandById(int id);
    }
}
