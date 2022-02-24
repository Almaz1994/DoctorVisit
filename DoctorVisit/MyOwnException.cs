namespace DoctorVisit
{
    class MyOwnException : Exception
    {
        public MyOwnException() : base("Попытка делить на нуль!") { }
    }
}
