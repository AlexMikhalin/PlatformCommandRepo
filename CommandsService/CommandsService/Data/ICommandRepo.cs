using CommandsService.Models;
using System.Collections.Generic;

namespace CommandsService.Data
{
    public interface ICommandRepo
    {

        bool SaveChanges();


        IEnumerable<Platform> GetAllPlatforms();

        void CreatePlatform(Platform platform);
        bool PlatformExits(int id);
        bool ExternalPlatformExists(int externalPlatformId);




        IEnumerable<Command> GetCommandsForPlatforms(int id);
        Command GetCommand(int platformid, int commandid);
        void CreateCommand(int platformid, Command command);

    }
}
