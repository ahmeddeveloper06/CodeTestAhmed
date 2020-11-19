using CodeTest.Context;
using CodeTest.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeTest.Features.Queries
{
    public class GetAllBooksQuery : IRequest<IEnumerable<book>>
    {
        public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<book>>
        {
            private readonly IApplicationContext _context;
            public GetAllBooksQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<book>> Handle(GetAllBooksQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.books.ToListAsync();
                if (productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}
