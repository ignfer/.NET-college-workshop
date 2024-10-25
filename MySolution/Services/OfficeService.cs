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
            new Office(
                1,
                "Maldonado - José Pedro Varela y Av. José Battle y Ordoñez",
                new List<Desk> {
                    new Desk(1, new Client("11111111",1)),
					new Desk(2, new Client("22222222",2)),
					new Desk(3, new Client("33333333",3)),
                },
                new List<Client> {
                    new Client("44444444",4),
                    new Client("55555555",5),
                    new Client("66666666",6),
                }
            ),
            new Office(
                2,
                "Punta del Este - C25 y El Mesana ",
				new List<Desk> {
					new Desk(4, new Client("11111111",1)),
					new Desk(5, new Client("22222222",2)),
					new Desk(6, new Client("33333333",3)),
				},
                new List<Client> {
                    new Client("44444444",4),
                    new Client("55555555",5),
                    new Client("66666666",6),
                }
			),
            new Office(
                3, "San carlos - Carlos reyes y J de Dios Curbelo",
				new List<Desk> {
					new Desk(7, new Client("11111111",1)),
					new Desk(8, new Client("22222222",2)),
					new Desk(9, new Client("33333333",3)),
				},
                new List<Client> {
                    new Client("44444444",4),
                    new Client("55555555",5),
                    new Client("66666666",6),
                }
			),
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
        public void RemoveClientFromQueue(int officeId, string clientCi) {
			_logger.LogInformation($"Removing client {clientCi} from queue of office {officeId}");
		}

        public Office getQueueFromOfficeReadOnly(int officeId) {
			_logger.LogInformation($"Getting read only queue of office {officeId}");
            return GetOfficeById(officeId);
		}
		public void getQueueFromOffice(int officeId)
		{
			_logger.LogInformation($"Getting queue of office {officeId}");
		}
	}
}
