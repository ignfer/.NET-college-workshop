using Microsoft.Extensions.Logging;
using MySolution.Models;

namespace MySolution.Services
{
    public class OfficeService
    {
        private readonly ILogger<OfficeService> _logger;

        public OfficeService(ILogger<OfficeService> logger)
        {
            _logger = logger;
        }

        //TODO: read office list from database
        private List<Office> _offices = new List<Office>
        {
            new Office(1, "Maldonado - José Pedro Varela y Av. José Battle y Ordoñez"),
            new Office(2, "Punta del Este - C25 y El Mesana "),
            new Office(3, "San carlos - Carlos reyes y J de Dios Curbelo"),
        };

        public List<Office> GetAllOffices() => _offices;

        public Office GetOfficeById(int id) => _offices.FirstOrDefault(o => o.Id == id);

        public String GetOfficeNameById(int id) => GetOfficeById(id).Name;

        public String GetSelectedOfficeName(int id){
            var office = GetOfficeById(id);
            return office != null ? office.Name : "N/A";
        }

        public void AddClientToQueue(int officeId, string clientCi) {
            _logger.LogInformation($"Adding client {clientCi} to queue of office {officeId}");
        }

    }
}
