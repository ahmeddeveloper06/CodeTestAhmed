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
    public class GetBookByDescribtionQuery : IRequest<book>
    {
        public String Describtion { get; set; }
        public class GetBookByDescribtionQueryHandler : IRequestHandler<GetBookByDescribtionQuery, book>
        {
            private readonly IApplicationContext _context;
            public GetBookByDescribtionQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<book> Handle(GetBookByDescribtionQuery query, CancellationToken cancellationToken)
            {
                var book = _context.books.Where(a => a.Description == query.Describtion).FirstOrDefault();
                if (book == null) return null;
                return book;
            }

        }
    }
}
