using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Messages;

namespace API.Controllers
{
    public class MessagesController : BaseApiController
    {
        private readonly DataContext _context;
        public MessagesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Message>>> GetMessages()
        {
            return await _context.Messages.ToListAsync();
        }

        [HttpGet("{id}")] // actvities/id
        public async Task<ActionResult<Message>> GetMessage(Guid id)
        {
            try
            {
                return await _context.Messages.FindAsync(id); 
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditMessage(Guid id, Message message)
        {
            message.Id = id;
            return Ok(await Mediator.Send(new Edit.Command {Message = message}));
        }
    }
}