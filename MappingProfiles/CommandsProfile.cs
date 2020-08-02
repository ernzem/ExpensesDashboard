// A mapping profile between data from Database and DTO
using AutoMapper;
using ExpensesDashboard.DataTransferObjects;
using ExpensesDashboard.Models;

namespace ExpensesDashboard.MappingProfiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // From source --> to target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
        }
    }
}