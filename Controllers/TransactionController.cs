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
            var transactionItems = _repository.GetAllTransactions();

            return Ok(_mapper.Map<IEnumerable<ReadDto>>(transactionItems));             
        }

        //GET api/transactions/{id}
        [HttpGet("{id}", Name="GetTransactionById")]        
        public ActionResult <ReadDto> GetTransactionById(int id)
        {
            var transactionItem = _repository.GetTransactionById(id);
            if (transactionItem != null)
            {
                return Ok(_mapper.Map<ReadDto>(transactionItem));
            }
            return NotFound();
        }

        //POST api/transactions
        [HttpPost]
        public ActionResult <ReadDto> CreateTransaction(CreateDto transactionCreateDto)
        {
            var transactionModel = _mapper.Map<Transaction>(transactionCreateDto);
            
            _repository.CreateTransaction(transactionModel);
            _repository.SaveChanges();

            var transactionReadDto = _mapper.Map<ReadDto>(transactionModel);
            
            return CreatedAtRoute(nameof(GetTransactionById), new {Id = transactionReadDto.Id}, transactionReadDto);
        }

        //PUT api/transactions
        [HttpPut("{id}")]
        public ActionResult UpdateTransaction(int id, UpdateDto transactionUpdateDto)
        {
            var transactionModelFromRepo = _repository.GetTransactionById(id);
            if(transactionModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(transactionUpdateDto, transactionModelFromRepo);

            // It's not necessary to update due the way entity framework works.But its good practice to use it.
            _repository.UpdateTransaction(transactionModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

         //PATCH api/transactions/{id}
        [HttpPatch("{id}")]
        public ActionResult TransactionUpdate(int id, JsonPatchDocument<UpdateDto> patchDoc) //Change to PatchTransaction
        {
            var transactionModelFromRepo = _repository.GetTransactionById(id);
            if(transactionModelFromRepo == null)
            {
                return NotFound();
            }

            var transactionToPatch = _mapper.Map<UpdateDto>(transactionModelFromRepo);
            patchDoc.ApplyTo(transactionToPatch, ModelState);

            if(!TryValidateModel(transactionToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(transactionToPatch, transactionModelFromRepo);

            _repository.UpdateTransaction(transactionModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/transactions/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTransaction(int id)
        {
            var transactionModelFromRepo = _repository.GetTransactionById(id);
            if(transactionModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteTransaction(transactionModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}