using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ExpensesDashboard.Data;
using ExpensesDashboard.Models;
using AutoMapper;
using ExpensesDashboard.DataTransferObjects;

namespace ExpensesDashboard.Controllers
{
    //api/
    [Route("api/expenses")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IExpensesDashRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(IExpensesDashRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // private readonly MockExpensesDashRepo _repository = new MockExpensesDashRepo();
        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));             
        }

        //GET api/commands/{id}
        [HttpGet("{id}")]        
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
        }
    }
}