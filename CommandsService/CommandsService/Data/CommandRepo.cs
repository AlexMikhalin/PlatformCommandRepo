using CommandsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandsService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;

        public CommandRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePlatform(Platform platform)
        {
           if(platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }
           _context.Platforms.Add(platform);
        }

        public void CreateCommand(int platformid, Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            command.PlatformId = platformid;
            _context.Commands.Add(command);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Command GetCommand(int platformid, int commandid)
        {
           return _context.Commands
                .Where(c => c.PlatformId == platformid && c.Id == commandid)
                .FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandsForPlatforms(int id)
        {
            return _context.Commands
                .Where(c => c.Id == id)
                .OrderBy(c => c.Platform.Name);
        }

        public bool PlatformExits(int id)
        {
            return _context.Platforms.Any(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool ExternalPlatformExists(int externalPlatformId)
        {
            return _context.Platforms.Any(p => p.ExternalID == externalPlatformId);
        }
    }
}
