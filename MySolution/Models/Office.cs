namespace MySolution.Models
{
    public class Office
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Office(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
