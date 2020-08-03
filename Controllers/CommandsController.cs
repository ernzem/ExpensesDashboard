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
    [Route("api/transactions")]
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

        //GET api/transactions
        [HttpGet]
        public ActionResult <IEnumerable<ReadDto>> GetAllTransactions()
        {
            var commandItems = _repository.GetAllTransactions();

            return Ok(_mapper.Map<IEnumerable<ReadDto>>(commandItems));             
        }

        //GET api/transactions/{id}
        [HttpGet("{id}", Name="GetTransactionById")]        
        public ActionResult <ReadDto> GetTransactionById(int id)
        {
            var commandItem = _repository.GetTransactionById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<ReadDto>(commandItem));
            }
            return NotFound();
        }

        //POST api/transactions
        [HttpPost]
        public ActionResult <ReadDto> CreateTransaction(CreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Transaction>(commandCreateDto);
            _repository.CreateTransaction(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<ReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetTransactionById), new {Id = commandReadDto.Id}, commandReadDto);
        }

        //PUT api/transactions
        [HttpPut("{id}")]
        public ActionResult UpdateTransaction(int id, UpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetTransactionById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            // It's not necessary to update due the way entity framework works.But its good practice to use it.
            _repository.UpdateTransaction(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

         //PATCH api/transactions/{id}
        [HttpPatch("{id}")]
        public ActionResult TransactionUpdate(int id, JsonPatchDocument<UpdateDto> patchDoc) //Change to PatchTransaction
        {
            var commandModelFromRepo = _repository.GetTransactionById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<UpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateTransaction(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/transactions/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTransaction(int id)
        {
            var commandModelFromRepo = _repository.GetTransactionById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteTransaction(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}