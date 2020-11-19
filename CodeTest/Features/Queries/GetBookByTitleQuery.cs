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
    public class GetBookByTitleQuery : IRequest<book>
    {
        public String Title { get; set; }
        public class GetBookByTitleQueryHandler : IRequestHandler<GetBookByTitleQuery, book>
        {
            private readonly IApplicationContext _context;
            public GetBookByTitleQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<book> Handle(GetBookByTitleQuery query, CancellationToken cancellationToken)
            {
                var book = _context.books.Where(a => a.Title == query.Title).FirstOrDefault();
                if (book == null) return null;
                return book;
            }

        }
    }
}

