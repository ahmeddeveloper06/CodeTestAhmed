using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTest.Features.Command;
using CodeTest.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CodeTest.Controllers
{
    public class BookController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost(template: "Create")]
        public async Task<IActionResult> Create([FromBody] CreatebookCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllBooksQuery()));
        }
        [HttpGet(template: "{Author}")]
        public async Task<IActionResult> GetByAuthor(string Author)
        {
            return Ok(await Mediator.Send(new GetBookByAuthorQuery { Author = Author }));
        }

        [HttpGet(template: "{Title}")]
        public async Task<IActionResult> GetByTitle(string Title)
        {
            return Ok(await Mediator.Send(new GetBookByTitleQuery { Title = Title }));
        }

        [HttpGet(template: "{Describtion}/")]
        public async Task<IActionResult> GetByDescribtion(string Describtion)
        {
            return Ok(await Mediator.Send(new GetBookByDescribtionQuery { Describtion = Describtion }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletebookByIdCommand { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatebookCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
