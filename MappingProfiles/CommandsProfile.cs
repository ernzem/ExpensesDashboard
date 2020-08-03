// A mapping profile between data from Database and DTO
using AutoMapper;
using ExpensesDashboard.DataTransferObjects;
using ExpensesDashboard.Models;

namespace ExpensesDashboard.MappingProfiles
{
    public class TransactionsProfile : Profile
    {
        public TransactionsProfile()
        {
            // Automapper mapping schemas.From source --> to target
            CreateMap<Transaction, ReadDto>();
            CreateMap<CreateDto, Transaction>();
            CreateMap<UpdateDto, Transaction>();
            CreateMap<Transaction, UpdateDto>();
        }
    }
}