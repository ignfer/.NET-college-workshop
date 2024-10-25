namespace MySolution.Models
{
	public class Client
	{
		public string Ci { get; set; }
		public int TicketNumber { get; set; }

		public Client(string ci, int ticketNumber)
		{
			this.Ci = ci;
			this.TicketNumber = ticketNumber;
		}
	}
}
