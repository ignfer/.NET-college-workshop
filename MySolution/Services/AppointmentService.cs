﻿using MySolution.Models;
using MySolution.Repositories;

namespace MySolution.Services
{
    public class AppointmentService
    {
        private readonly QueueService _queueService;
        private readonly AppointmentRepository _appointmentRepository;
        private readonly DeskRepository _deskRepository;
        private readonly ILogger<AppointmentService> _logger;

        public AppointmentService(ILogger<AppointmentService> logger, AppointmentRepository appointmentRepo, QueueService queueService, DeskRepository deskRepository)
        {
            _logger = logger;
            _appointmentRepository = appointmentRepo;
            _queueService = queueService;
            _deskRepository = deskRepository;
        }

        public (int LastHour, int LastWeek, int LastMonth) GetAppointmentStats()
        {
            var now = DateTime.Now;

            var appointments = _appointmentRepository.GetAll();
            return (
                LastHour: appointments.Count(a => a.StartDate >= now.AddHours(-1)),
                LastWeek: appointments.Count(a => a.StartDate >= now.AddDays(-7)),
                LastMonth: appointments.Count(a => a.StartDate >= now.AddMonths(-1))
            );
        }

        public Appointment? GetLastCalledAppointment()
        {
            return _appointmentRepository.GetAll()
                .OrderByDescending(q => q.StartDate)
                .FirstOrDefault();
        }

        public void GetNextInQueue(string deskName)
        {
            Queue? nextQueue = _queueService.GetNextInQueue();
            Desk? desk = _deskRepository.GetByName(deskName);

            if (nextQueue != null && desk != null)
            {
                var newAppointment = new Appointment
                {
                    QueueId = nextQueue.Id,
                    StartDate = DateTime.Now,
                    DeskId = desk.Id,
                };

                _logger.LogInformation($"Registering new appointment with CI {nextQueue.CINumber}");
                _appointmentRepository.Add(newAppointment);
            } else
            {
                _logger.LogInformation($"Not next in queue found");
            }

        }
    }
}