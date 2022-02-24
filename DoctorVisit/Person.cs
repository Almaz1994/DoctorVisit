namespace DoctorVisit
{
    public abstract class Person
    {    
        public string LastName { get; set; }      
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public Person(string lastname, string firstname, string middlename)
        {
            LastName = lastname;
            FirstName = firstname;
            MiddleName = middlename;
        }
    }
}
