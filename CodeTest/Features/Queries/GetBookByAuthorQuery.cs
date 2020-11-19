using CodeTest.Context;
using CodeTest.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeTest.Features.Queries
{
    public class GetBookByAuthorQuery : IRequest<book>
    {
        public String Author { get; set; }
        public class GetBookByAuthorQueryHandler : IRequestHandler<GetBookByAuthorQuery, book>
        {
            private readonly IApplicationContext _context;
            public GetBookByAuthorQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<book> Handle(GetBookByAuthorQuery query, CancellationToken cancellationToken)
            {
                var book = _context.books.Where(a => a.Author == query.Author).FirstOrDefault();
                if (book== null) return null;
                return book;
            }
            
        }
    }
}
