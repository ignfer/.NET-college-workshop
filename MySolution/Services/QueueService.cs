using Microsoft.EntityFrameworkCore;
using MySolution.Repositories;

namespace MySolution.Services
{
    public class QueueService
    {
        private readonly QueueRepository _queueRepository;
        private readonly ILogger<QueueService> _logger;

        public QueueService(ILogger<QueueService> logger, QueueRepository queueRepository)
        {
            _logger = logger;
            _queueRepository = queueRepository;
        }

        public void AddUserToQueue(string ciNumber)
        {
            var queue = new Queue
            {
                Date = DateTime.Now, // Set the current time
                Status = "Waiting",  // New users are "Waiting" initially
                CINumber = ciNumber
            };
            _logger.LogInformation($"Adding client with CI {ciNumber} to QUEUE");
            _queueRepository.Add(queue);
        }


        public IEnumerable<Queue> GetQueue()
        {
            return _queueRepository.GetAll().Select(q => new Queue
            {
                Id = q.Id,
                Date = q.Date,
                Status = q.Status,
                CINumber = q.CINumber
            });
        }

        public int GetWaitingQueue()
        {
            return _queueRepository.GetAll()
                .Count(q => q.Status == "Waiting");
        }

        public Queue? GetNextInQueue()
        {
            var waitingQueues = _queueRepository.GetAll()
                .Where(q => q.Status == "Waiting")
                .OrderBy(q => q.Date)
                .Select(q => new Queue
                {
                    Id = q.Id,
                    Date = q.Date,
                    Status = q.Status,
                    CINumber = q.CINumber
                });

            return waitingQueues.FirstOrDefault();
        }

        public void SetCompleted(long queueId)
        {
            _queueRepository.SetCompleted(queueId);
        }
    }
}
