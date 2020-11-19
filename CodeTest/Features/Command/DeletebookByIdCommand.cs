using CodeTest.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeTest.Features.Command
{
    public class DeletebookByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    

    public class DeletebookByIdCommandHandler : IRequestHandler<DeletebookByIdCommand, int>
    {
        private readonly IApplicationContext _context;
        public DeletebookByIdCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeletebookByIdCommand command, CancellationToken cancellationToken)
        {
            var product = await _context.books.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
            if (product == null) return default;
            _context.books.Remove(product);
            await _context.SaveChanges();
            return product.Id;
        }
    }
}
}
