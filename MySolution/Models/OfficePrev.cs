namespace MySolution.Models
{
    public class OfficePrev
    {
        public int Id { get; set; }
        public string Name { get; set; }

		public List<DeskPrev> InProgressDesks { get; set; } = new List<DeskPrev>();
        public List<ClientPrev> WaitingClients { get; set; } = new List<ClientPrev>();

		public OfficePrev(int id, string name, List<DeskPrev> inProgressDesks, List<ClientPrev> waitingClients)
		{
            Id = id;
            Name = name;
			InProgressDesks = inProgressDesks;
            WaitingClients = waitingClients;
		}
    }
}
