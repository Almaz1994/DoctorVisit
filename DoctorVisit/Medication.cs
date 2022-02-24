namespace DoctorVisit
{
    public class Medication<T, TT>
    {
        public string Name { get; set; }
        public T Price { get; set; }
        public TT Count { get; set; }
        public Medication(string name, T price, TT count)
        {
            Name = name;
            Price = price;
            Count = count;
        }
    }
}
