using Microsoft.Extensions.Logging;
using MySolution.Models;

namespace MySolution.Services
{
    public class OfficeService
    {
        private readonly ILogger<OfficeService> _logger;
        private int _selectedOfficeId = -1;
        public event Action OnChange;

        public OfficeService(ILogger<OfficeService> logger)
        {
            _logger = logger;
        }

        public int SelectedOffice
        {
            get => _selectedOfficeId;
            set
            {
                if (_selectedOfficeId != value)
                {
                    _logger.LogInformation($"[OFFICESERVICE] - _selectedOffice change from {_selectedOfficeId} to {value}");
                    _selectedOfficeId = value;
                    OnChange?.Invoke();
                    _logger.LogInformation($"[OFFICESERVICE] - {GetOfficeById(1).Name}");
                }
            }
        }

        private List<Office> _offices = new List<Office>
        {
            new Office(1, "Maldonado - José Pedro Varela y Av. José Battle y Ordoñez"),
            new Office(2, "Punta del Este - C25 y El Mesana "),
            new Office(3, "San carlos - Carlos reyes y J de Dios Curbelo"),
        };

        public List<Office> GetAllOffices() => _offices;

        public Office GetOfficeById(int id) => _offices.FirstOrDefault(o => o.Id == id);

        public String GetOfficeNameById(int id) => GetOfficeById(id).Name;

        public String GetSelectedOfficeName(){
            var office = GetOfficeById(_selectedOfficeId);
            return office != null ? office.Name : "N/A";
        }

    }
}
