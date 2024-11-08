namespace MySolution.Models
{
	public class Client
	{
		public string Ci { get; set; }

		public string Name { get; set; }
		public int TicketNumber { get; set; }

		public Client(string ci, string name, int ticketNumber)
		{
			this.Ci = ci;
			this.Name = name;
			this.TicketNumber = ticketNumber;
		}
	}
}
