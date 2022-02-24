using System.Collections.Generic;

namespace DoctorVisit
{
    public class Patient: Person
    {
        public string Diagnose { get; set; }
        public List<string> Medication { get; set; }
        public List<Medication<double, int>> Med { get; set; }
        public Patient(string lastname, string firstname, string middlename) :base(lastname, firstname, middlename) { }

        public string GetDiagnose(Doctor d)
        {
            return Diagnose;
        }           
        public List<string> GetMedication(Doctor d)
        {
            return Medication;
        }
        public List<Medication<double, int>> BuyMedication(List<Medication<double, int>> med)
        {
            Med = med;
            return Med;
        }
    }
}
