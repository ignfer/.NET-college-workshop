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
            return _context.Queues;
        }

        public Queue? GetById(long id)
        {
            return _context.Queues
                .FirstOrDefault(q => q.Id == id);
        }

        public void Add(Queue queue)
        {
            _context.Queues.Add(queue);
            _context.SaveChanges();
        }

        public void SetCompleted(long queueId)
        {
            var queue = _context.Queues.FirstOrDefault(q => q.Id == queueId);
            if (queue != null)
            {
                queue.Status = "Completed";
                _context.SaveChanges();
            }
        }
    }

}
