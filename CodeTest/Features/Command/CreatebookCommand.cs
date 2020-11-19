using CodeTest.Context;
using CodeTest.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeTest.Features.Command
{
    public class CreatebookCommand: IRequest<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int published { get; set; }
        public string Description { get; set; }
    
    public class CreatebookCommandHandler : IRequestHandler<CreatebookCommand, int>
    {
        private readonly IApplicationContext _context;
        public CreatebookCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreatebookCommand command, CancellationToken cancellationToken)
        {
            var b = new book();
            b.Title = command.Title;
            b.Author = command.Author;
            b.published = command.published;
            b.Description = command.Description;
           
            _context.books.Add(b);
            await _context.SaveChanges();
            return b.Id;
        }
    }
}
}

