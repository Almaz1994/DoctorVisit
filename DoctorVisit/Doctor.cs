namespace DoctorVisit
{   
    public class Doctor: Person
    {
        public string Post { get; set; }
        public Doctor(string lastname, string firstname, string middlename, string post) :base(lastname, firstname, middlename)
        {
            Post = post;
        }
        public void SetDiagnose(Patient p, string diagnose)
        {
            p.Diagnose = diagnose;
        }      
        public void SetMedication(Patient p, List<string> medication)
        {
            p.Medication = medication;          
        }
    }
}
