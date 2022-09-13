namespace Command_Saver_Test.Data.Commands
{
    using Command_Saver_data;
    using Command_Saver_data.Models;
    using FakeItEasy;

    public class CommandCommandsTest
    {
        private CommandSaverDbContext CommandSaverDbContext = A.Fake<CommandSaverDbContext>();
        private Command command = A.Fake<Command>();
    }
}
