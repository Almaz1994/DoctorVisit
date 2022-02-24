namespace DoctorVisit
{   
    public class Doctor: Person, IEducation
    {
        public string Education { get; set; }
        public string Company { get; set; }
        public string Post { get; set; }
        public Doctor(string lastname, string firstname, string middlename, string education, string company, string post) :base(lastname, firstname, middlename)
        {
            Education = education;
            Company = company;
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
