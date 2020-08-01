using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ExpensesDashboard.Data;
using ExpensesDashboard.Models;

namespace ExpensesDashboard.Controllers
{
    //api/
    [Route("api/expenses")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IExpensesDashRepo _repository;

        public CommandsController(IExpensesDashRepo repository)
        {
            _repository = repository;
        }

        // private readonly MockExpensesDashRepo _repository = new MockExpensesDashRepo();
        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(commandItems);             
        }

        //GET api/commands/{id}
        [HttpGet("{id}")]        
        public ActionResult <Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            return Ok(commandItem);
        }
    }
}