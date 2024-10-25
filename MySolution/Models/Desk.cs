namespace MySolution.Models
{
	public class Desk
	{
		public int Id { get; set; }
		public Client Client { get; set; }

		public Desk(int id, Client client)
		{
			Id = id;
			Client = client;
		}
	}
}
