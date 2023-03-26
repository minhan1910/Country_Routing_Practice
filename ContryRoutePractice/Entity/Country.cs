namespace ContryRoutePractice.Entity
{
    public abstract class Country
    {
        public Country(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }
        public string Name { get; private set; }

        public string IdNameFormatted => $"{Id}, {Name}";

       
    }
}
