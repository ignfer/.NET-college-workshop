namespace MySolution.Models
{
	public class DeskPrev
	{
		public int Id { get; set; }
		public ClientPrev Client { get; set; }

		public DeskPrev(int id, ClientPrev client)
		{
			Id = id;
			Client = client;
		}
	}
}
