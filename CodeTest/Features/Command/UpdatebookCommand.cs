using CodeTest.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeTest.Features.Command
{
    public class UpdatebookCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int published { get; set; }
        public string Description { get; set; }

        public class UpdatebookCommandHandler : IRequestHandler<UpdatebookCommand, int>
        {
            private readonly IApplicationContext _context;
            public UpdatebookCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdatebookCommand command, CancellationToken cancellationToken)
            {
                var b = _context.books.Where(a => a.Id == command.Id).FirstOrDefault();

                if (b == null)
                {
                    return default;
                }
                else
                {
                    b.Title = command.Title;
                    b.Author = command.Author;
                    b.published = command.published;
                    b.Description = command.Description;
                    await _context.SaveChanges();
                    return b.Id;
                }
            }
        }
    }
}
