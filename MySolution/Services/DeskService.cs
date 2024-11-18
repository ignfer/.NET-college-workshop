using Microsoft.EntityFrameworkCore;
using MySolution.Data;
using MySolution.Repositories;

namespace MySolution.Services
{
    public class DeskService
    {
        private readonly DeskRepository _deskRepository;


        public DeskService(DeskRepository deskRepository)
        {
            _deskRepository = deskRepository;
        }

        public void AddDeskIfNotExists(string name)
        {
            Desk persistedDesk = _deskRepository.GetByName(name);
            if (persistedDesk == null)
            {
                Desk desk = new Desk();
                desk.Name = name;

                _deskRepository.AddDesk(desk);
            }
        }

    }
}
