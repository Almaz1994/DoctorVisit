namespace DoctorVisit
{
    public class Medication
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public Medication(string name, double price, int count)
        {
            Name = name;
            Price = price;
            Count = count;
        }
    }
}
