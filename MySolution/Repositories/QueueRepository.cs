using Microsoft.EntityFrameworkCore;
using MySolution.Data;
using MySolution.Models;

namespace MySolution.Repositories
{
    public class QueueRepository
    {
        private readonly AppDbContext _context;

        public QueueRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Queue> GetAll()
        {
            return _context.Queues
                .AsNoTracking()
                .ToList();
        }

        public Queue? GetById(long id)
        {
            return _context.Queues
                .AsNoTracking()
                .FirstOrDefault(q => q.Id == id);
        }

        public void Add(Queue queue)
        {
            _context.Queues.Add(queue);
            _context.SaveChanges();
        }

        public void Update(Queue queue)
        {
            _context.Queues.Update(queue);
            _context.SaveChanges();
        }
    }

}
