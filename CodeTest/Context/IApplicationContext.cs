using CodeTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeTest.Context
{
    public interface IApplicationContext
    {
        DbSet<book> books { get; set; }

        Task<int> SaveChanges();
    }
}