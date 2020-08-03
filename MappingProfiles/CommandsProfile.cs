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
            // Automapper mapping schemas.From source --> to target
            CreateMap<Transaction, CommandReadDto>();
            CreateMap<CommandCreateDto, Transaction>();
            CreateMap<CommandUpdateDto, Transaction>();
            CreateMap<Transaction, CommandUpdateDto>();
        }
    }
}