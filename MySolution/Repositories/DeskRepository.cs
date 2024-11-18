using Microsoft.EntityFrameworkCore;
using MySolution.Data;
using MySolution.Models;
using Radzen.Blazor.Rendering;

namespace MySolution.Repositories
{
    public class DeskRepository
    {
        private readonly AppDbContext _dbContext;

        public DeskRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Desk> GetAll()
        {
            return _dbContext.Desks
                .AsNoTracking()
                .ToList();
        }

        public Desk? GetById(long id)
        {
            return _dbContext.Desks
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }

        public void AddDesk(Desk desk)
        {
            _dbContext.Desks.Add(desk);
            _dbContext.SaveChanges();
        }

        public Desk? GetByName(string name)
        {
            return _dbContext.Desks
                .AsNoTracking()
                .FirstOrDefault(p => p.Name == name);
        }
    }
}
