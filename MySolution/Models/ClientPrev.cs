namespace MySolution.Models
{
	public class ClientPrev
    {
		public string Ci { get; set; }

		public string Name { get; set; }
		public int TicketNumber { get; set; }

		public ClientPrev(string ci, string name, int ticketNumber)
		{
			this.Ci = ci;
			this.Name = name;
			this.TicketNumber = ticketNumber;
		}
	}
}
