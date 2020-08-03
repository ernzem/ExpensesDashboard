using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ExpensesDashboard.Data;
using ExpensesDashboard.Models;
using AutoMapper;
using ExpensesDashboard.DataTransferObjects;
using Microsoft.AspNetCore.JsonPatch;

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
            var commandModel = _mapper.Map<Transaction>(commandCreateDto);
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

         //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult ExpenseUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetExpenseById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateExpense(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetExpenseById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteExpense(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}