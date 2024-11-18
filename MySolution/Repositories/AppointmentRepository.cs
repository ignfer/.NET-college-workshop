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
                .AsNoTracking()
                .Include(a => a.Desk)
                .FirstOrDefault(a => a.Id == id);
        }

        public void Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }
    }

}