using Microsoft.EntityFrameworkCore;
using MySolution.Data;
using MySolution.Models;

namespace MySolution.Repositories
{
    public class AppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments
                .AsNoTracking()
                .Include(a => a.Desk)
                .Include(a => a.Queue)
                .ToList();
        }

        public Appointment? GetById(long id)
        {
            return _context.Appointments
                .Include(a => a.Desk)
                .FirstOrDefault(a => a.Id == id);
        }

        public void Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void EndAppointment(Appointment appointment)
        {
            appointment.EndDate = DateTime.Now;
            _context.SaveChanges();
        }

        public double GetAverageWaitingTime()
        {
            // Fetch all completed queues that have a corresponding appointment
            var completedQueuesWithAppointments = _context.Appointments
                .Include(a => a.Queue)
                .Where(a => a.Queue.Status == "Completed")
                .Select(a => new
                {
                    QueueDate = a.Queue.Date,
                    AppointmentStartDate = a.StartDate
                })
                .ToList();

            // If no completed queues with appointments exist, return 0
            if (!completedQueuesWithAppointments.Any())
                return 0;

            // Calculate and return the average waiting time
            return completedQueuesWithAppointments
                .Average(item => (item.AppointmentStartDate - item.QueueDate).TotalMinutes);
        }
    }

}