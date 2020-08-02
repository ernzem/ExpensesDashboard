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

        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllExpenses()
        {
            var commandItems = _repository.GetAllExpenses();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));             
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name="GetExpenseById")]        
        public ActionResult <CommandReadDto> GetExpenseById(int id)
        {
            var commandItem = _repository.GetExpenseById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult <CommandReadDto> CreateExpense(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateExpense(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetExpenseById), new {Id = commandReadDto.Id}, commandReadDto);
        }

        //PUT api/commands
        [HttpPut("{id}")]
        public ActionResult UpdateExpense(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetExpenseById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            // It's not necessary to update due the way entity framework works.But its good practice to use it.
            _repository.UpdateExpense(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();


        }
    }
}