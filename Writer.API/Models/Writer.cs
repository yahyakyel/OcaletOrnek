namespace Writer.API.Models
{
    public class Writer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Writer()
        {

        }
        public Writer(int id,string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
