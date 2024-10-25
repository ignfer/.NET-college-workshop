namespace MySolution.Models
{
    public class Office
    {
        public int Id { get; set; }
        public string Name { get; set; }

		public List<Desk> InProgressDesks { get; set; } = new List<Desk>();
        public List<Client> WaitingClients { get; set; } = new List<Client>();

		public Office(int id, string name, List<Desk> inProgressDesks, List<Client> waitingClients)
		{
            Id = id;
            Name = name;
			InProgressDesks = inProgressDesks;
            WaitingClients = waitingClients;
		}
    }
}
